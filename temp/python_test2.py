import os
import sys
import argparse
import glob
import pandas as pd

def main():
    # Set up command-line arguments:
    #   input_folder: folder containing CSV files
    #   output_folder: folder to write the combined CSV file
    #   max_rows: maximum number of rows (including header) in output CSV (0 means no limit)
    parser = argparse.ArgumentParser(
        description="Combine CSV files from an input folder into one CSV file in an output folder using pandas."
    )
    parser.add_argument("input_folder", help="Path to the input folder containing CSV files.")
    parser.add_argument("output_folder", help="Path to the output folder for the combined CSV file.")
    parser.add_argument("max_rows", type=int, help="Maximum number of rows to write (including the header). Set to 0 for no limit.")

    args = parser.parse_args()
    input_folder = args.input_folder
    output_folder = args.output_folder
    max_rows = args.max_rows

    # Validate that the input folder exists and is a directory.
    if not os.path.isdir(input_folder):
        print(f"Error: The input folder '{input_folder}' does not exist or is not a directory.")
        sys.exit(1)

    # Ensure the output folder exists. If it does not, create it.
    if not os.path.exists(output_folder):
        os.makedirs(output_folder)

    # Find all CSV files in the input folder (non-recursive)
    csv_files = glob.glob(os.path.join(input_folder, "*.csv"))
    if not csv_files:
        print("No CSV files found in the input folder.")
        sys.exit(1)

    # Read CSV files into pandas DataFrames and collect them in a list.
    df_list = []
    for file in csv_files:
        try:
            df = pd.read_csv(file)
            df_list.append(df)
        except Exception as e:
            print(f"Error reading {file}: {e}")

    if not df_list:
        print("No CSV data could be loaded from the provided files.")
        sys.exit(1)

    # Concatenate all DataFrames
    combined_df = pd.concat(df_list, ignore_index=True)

    # If max_rows > 0, limit the output CSV to at most max_rows rows (including header).
    # Since pandas writes the header separately, we need to take (max_rows-1) data rows.
    if max_rows > 0:
        if max_rows > 1:
            combined_df = combined_df.head(max_rows - 1)
        else:
            # max_rows is 1, so only the header will be output and no data rows.
            combined_df = combined_df.iloc[0:0]

    # Define the output file path and write the combined DataFrame to CSV.
    output_file = os.path.join(output_folder, "combined.csv")
    combined_df.to_csv(output_file, index=False)
    print(f"Combined CSV file has been created at: {output_file}")

if __name__ == "__main__":
    main()
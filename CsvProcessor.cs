using System.Data;

namespace button_practice
{
    internal class CsvProcessor
    {
        public static DataTable ReadCsv(string filePath)
        {
            DataTable dataTable = new();

            // read the header row
            // ヘッダー行を読む
            using StreamReader reader = new(filePath);
            string headerLine = reader.ReadLine() ?? throw new InvalidDataException(".csvは空です。");

            // split header to get column names
            // ヘッダーを分割してカラム名を取得
            string[] headers = headerLine.Split(',');

            // add columns to datatable
            // データテーブルに欄を追加する
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            // add values to datatable
            // データテーブルに値を追加する
            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split(",");
                dataTable.Rows.Add(values);
            }

            // check for specified column names and assigns them to the correct positions in the datatable
            // 指定されたカラム名をチェックし、データテーブルの正しい位置に割り当てる。
            DataColumn jpCol = dataTable.Columns.Cast<DataColumn>().FirstOrDefault(col => col.ColumnName.Equals("日本語", StringComparison.OrdinalIgnoreCase));
            DataColumn enCol = dataTable.Columns.Cast<DataColumn>().FirstOrDefault(col => col.ColumnName.Equals("英語", StringComparison.OrdinalIgnoreCase));

            if(jpCol != null && enCol != null)
            {
                if(jpCol.Ordinal != 0)
                {
                    dataTable.Columns[jpCol.Ordinal].SetOrdinal(0);
                }

                if(enCol.Ordinal != 1)
                {
                    dataTable.Columns[enCol.Ordinal].SetOrdinal(1);
                }
            }
            else
            {
                throw new InvalidDataException(".csvには必須カラム名が含まれていません。\n「日本語」と「英語」カラムを持つ.csvファイルを使用してください。");
            }

            return dataTable;
        }
    }
}


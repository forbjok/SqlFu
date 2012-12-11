namespace SqlFu.DDL
{
    public interface IDatabaseTools:ICreateDDL
    {
        void DropTable(string tableName);
        bool TableExists(string name, string schema=null);
        void RenameTable(string oldName, string newName);
        void TruncateTable(string name);
        bool ConstraintExists(string name, string schema = null);
        bool IndexExists(string name, string table, string schema = null);
        bool TableHasColumn(string table, string column, string schema = null);
        bool TableHasPrimaryKey(string table, string schema = null);
        string GetPrimaryKeyName(string tableName, string schema = null);
    }
}
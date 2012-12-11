namespace SqlFu.DDL
{
    public interface ICreateConstraints:ISupportSpecificConstraintsOptions
    {
        /// <summary>
        /// If key name is missing it will default to PK_[table name]
        /// </summary>
        /// <param name="columnsNames">Format: column[,...column]</param>
        /// <param name="keyName">Default is PK_[table name]</param>
        /// <returns></returns>
        ICreateConstraints AddPrimaryKeyOn(string columnsNames, string keyName = null);
        ICreateConstraints AddUniqueConstraintOn(string columnsNames, string constraintName = null);

        /// <summary>
        /// Creates a foreign key relation
        /// </summary>
        /// <param name="columnNames"> </param>
        /// <param name="parentTable"></param>
        /// <param name="parentColumns"> </param>
        /// <param name="onUpdate"> </param>
        /// <param name="onDelete"> </param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        ICreateConstraints AddForeignKeyOn(string columnNames, string parentTable, string parentColumns, ForeignKeyRelationCascade onUpdate = ForeignKeyRelationCascade.NoAction, ForeignKeyRelationCascade onDelete = ForeignKeyRelationCascade.NoAction, string keyName = null);

        ICreateConstraints AddCheck(string expression, string constraintName);

        IDefineSpecificConstraintsOptions this[string name] { get; }
    }

    public interface ISupportSpecificConstraintsOptions
    {
        IDefineSpecificConstraintsOptions IfDatabaseIs(DbEngine engine);
    }


    public interface IDefineSpecificConstraintsOptions : ISupportSpecificConstraintsOptions
    {
        IDefineSpecificConstraintsOptions PrimaryKeyOptions(params DbSpecificOption[] options);
        IDefineSpecificConstraintsOptions UniqueOptions(string keyName, params DbSpecificOption[] options);
        IDefineSpecificConstraintsOptions AddConstraint(string definition);
        IDefineSpecificConstraintsOptions Redefine(string definition);
    }
}
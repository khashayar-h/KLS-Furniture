namespace KLS_Furniture.Model.Lookups
{
    /// <summary>
    /// Generic lookup row for combo boxes.
    /// </summary>
    public class IdNameLookupItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public override string ToString()
        {
            return Name;
        }
    }
}
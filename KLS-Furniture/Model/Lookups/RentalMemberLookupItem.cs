namespace KLS_Furniture.Model.Lookups
{
    /// <summary>
    /// Lightweight member lookup item used in the rental screen.
    /// </summary>
    public class RentalMemberLookupItem
    {
        public int MemberId { get; set; }
        public string DisplayText { get; set; } = "";

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
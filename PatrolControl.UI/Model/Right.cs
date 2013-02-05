namespace PatrolControl.UI.Model
{
    public partial class Right
    {
        public Right(int id, string screen)
        {
            Id = id;
            Screen = screen;
        }

        public int Id { get; set; }
        public string Screen { get; set; }
    }
}
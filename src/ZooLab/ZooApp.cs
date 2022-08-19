namespace ZooLab
{
    public class ZooApp
    {
        private List<Zoo> _zoos = new List<Zoo>();

        public void AddZoo(Zoo zoo)
        {
            _zoos.Add(zoo);
        }

        public List<Zoo> GetZoos()
        {
            return _zoos;
        }
    }
}
namespace GP.Prescriptions.BusinessObjects.Classes
{
    using System.Collections.Generic;

    public sealed class Region
    {
        // Type-Safe-Enum pattern

        #region Private Fields

        private readonly string name;
        private readonly int value;

        #endregion

        #region Public Fields

        public static readonly Region EastMidlands = new Region(0, "East Midlands");
        public static readonly Region EastOfEngland = new Region(1, "East of England");
        public static readonly Region London = new Region(2, "London");
        public static readonly Region NorthEast = new Region(3, "North East");
        public static readonly Region NorthWest = new Region(4, "North West");
        public static readonly Region SouthEast = new Region(5, "South East");
        public static readonly Region SouthWest = new Region(6, "South West");
        public static readonly Region WestMidlands = new Region(7, "West Midlands");
        public static readonly Region YorkshireAndTheHumber = new Region(8, "Yorkshire and The Humber");

        public static readonly List<Region> All = new List<Region>(9)
                                                      {
                                                          EastMidlands,
                                                          EastOfEngland,
                                                          London,
                                                          NorthEast,
                                                          NorthWest,
                                                          SouthEast,
                                                          SouthWest,
                                                          WestMidlands,
                                                          YorkshireAndTheHumber
                                                      };

        #endregion

        #region Constructors

        private Region(int value, string name)
        {
            this.value = value;
            this.name = name;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return name;
        }

        public bool Equals(Region obj)
        {
            return this.name == obj.name && this.value == obj.value;
        }

        #endregion
    }
}

using System;

namespace View
{
    public class BoatList
    {
        public Views NextView { get; set; }
        public BoatList()
        {
            NextView = Views.Start;
        }
           
        public Views Run()
        {

            return NextView;
        }
    }
}
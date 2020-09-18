using System;

namespace View
{
    public class Boat
    {
        public Views NextView { get; set; }
        public Boat() 
        {
            NextView = Views.Start;
        }

        public Views Run()
        {

            return NextView;
        }
        
    }

}
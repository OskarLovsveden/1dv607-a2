using System;

namespace View
{
    public class Boat
    {
        // private Views nextView;
        
        public Views NextView { get; set; }
        public Boat() {
            NextView = Views.Start;
        }

        public Views Run()
        {
            
            return NextView;
        }
        
    }

}
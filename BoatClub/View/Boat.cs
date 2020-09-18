using System;

namespace View
{
    public class Boat
    {
        public ViewType NextView { get; set; }
        public Boat() 
        {
            NextView = ViewType.Start;
        }

        public ViewType Run()
        {

            return NextView;
        }
        
    }

}
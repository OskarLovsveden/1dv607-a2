using System;

namespace View
{
    public class BoatList
    {
        public ViewType NextView { get; set; }
        public BoatList()
        {
            NextView = ViewType.Start;
        }
           
        public ViewType Run()
        {

            return NextView;
        }
    }
}
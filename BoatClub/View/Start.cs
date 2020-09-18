using System;

namespace View
{
    public class Start
    {
        public Views NextView { get; set; }
        public Start()
        {
            NextView = Views.Start;
        }
        
        public Views Run()
        {

            return NextView;
        }
    }
}
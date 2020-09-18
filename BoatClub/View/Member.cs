using System;

namespace View
{
    public class Member
    {
        public Views NextView { get; set; }
        public Member()
        {
            NextView = Views.Start;
        }

        public Views Run()
        {

            return NextView;
        }
        
    }
}
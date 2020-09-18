using System;

namespace View
{
    public class MemberList
    {
        public Views NextView { get; set; }
        public MemberList()
        {
            NextView = Views.Start;
        }
        
        public Views Run()
        {

            return NextView;
        }
    }
}
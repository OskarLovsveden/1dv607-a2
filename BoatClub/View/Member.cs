using System;

namespace View
{
    public class Member
    {
        public ViewType NextView { get; set; }
        public Member()
        {
            NextView = ViewType.Start;
        }

        public ViewType Run()
        {

            return NextView;
        }
        
    }
}
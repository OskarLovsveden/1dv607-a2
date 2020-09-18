using System;

namespace View
{
    public class MemberList
    {
        public ViewType NextView { get; set; }
        public MemberList()
        {
            NextView = ViewType.Start;
        }
        
        public ViewType Run()
        {

            return NextView;
        }
    }
}
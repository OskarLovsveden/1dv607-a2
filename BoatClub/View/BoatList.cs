using System;
using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class BoatList
    {
        public MenuItems MenuItems { get; set; }

        public BoatList()
        {
            List<string> boats = new List<string>() {
                "Boat1",
                "Boat2",
                "Boat3",
                "Boat4",
                "Boat5"
            };

            MenuItems = new MenuItems("All boats");
            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(boats[copyIndex], () => Console.WriteLine(boats[copyIndex]), $"{copyIndex + 1}", ViewType.Boat));
            }
        }
    }
}
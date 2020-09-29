using System.Collections.Generic;
using Model.Menu;

namespace View
{
    public class Boat
    {
        private Model.BoatList _boatList = new Model.BoatList();
        public MenuItems MenuItems { get; set; }

        public void ShowBoats(Model.Member member)
        {
            List<Model.Boat> boats = _boatList.GetMembersBoats(member);
            MenuItems = new MenuItems("Boats:");
            for (int i = 0; i < boats.Count; i++)
            {
                int copyIndex = i;
                MenuItems.Add(new MenuItem(
                    $"{copyIndex + 1})\n{boats[copyIndex].ToString()}",
                    () => ShowBoat(boats[copyIndex], member),
                    $"{copyIndex + 1}",
                    ViewType.Boat
                ));
            }

            MenuItems.Add(new MenuItem("0) Go Back", () => {}, "0", ViewType.Member));
        }

        private void ShowBoat(Model.Boat boat, Model.Member member)
        {
            MenuItems = new MenuItems($"Member\n{boat.Name} - {boat.ID}");

            MenuItems.Add(new MenuItem("1) Update type", () => {}, "1", ViewType.Boat));
            MenuItems.Add(new MenuItem("2) Update length", () =>{}, "2", ViewType.Boat));
            MenuItems.Add(new MenuItem("3) Delete boat", () =>{}, "3", ViewType.Boat));
            MenuItems.Add(new MenuItem("0) Go back", () => ShowBoats(member), "0", ViewType.Boat));
        }
    }
}
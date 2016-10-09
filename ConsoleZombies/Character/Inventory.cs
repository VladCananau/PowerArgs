﻿using PowerArgs.Cli;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleZombies
{
    public class Inventory : ObservableObject
    {
        public List<Weapon> AvailableWeapons { get; private set; }

        public Weapon PrimaryWeapon { get { return Get<Weapon>(); } private set { Set(value); } }
        public Weapon ExplosiveWeapon { get { return Get<Weapon>(); } private set { Set(value); } }

        public Inventory()
        {
            AvailableWeapons = new List<Weapon>();
            PrimaryWeapon = new Pistol() { AmmoAmount = 20 };
            ExplosiveWeapon = new RPGLauncher() { AmmoAmount = 2 } ;
            AvailableWeapons.Add(PrimaryWeapon);
            AvailableWeapons.Add(ExplosiveWeapon);
        }

        public bool TryGet<T>(out T weapon) where T : Weapon
        {
            weapon = (T)AvailableWeapons.Where(w => w is T).SingleOrDefault();
            return weapon != null;
        }
    }
}

using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship

    {
        private string name;
        private StarSystem location;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private IList<Enhancement> enhancements;


        protected Starship(string name, StarSystem location, int health, int shields, int damage, double fuel)
        {
            this.Name = name;
            this.Location = location;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.enhancements = new List<Enhancement>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public StarSystem Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
                if (this.health<0)
                {
                    this.health = 0;
                }
            }
        }

        public int Shields
        {
            get
            {
                return this.shields;
            }

            set
            {
                this.shields = value;
                if (this.shields < 0)
                {
                    this.shields = 0;
                }
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
            }
        }

        public double Fuel
        {
            get
            {
                return this.fuel;
            }

            set
            {
                this.fuel = value;
            }
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }


        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null.");
            }
            this.enhancements.Add(enhancement);
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                if (this.enhancements.Count > 0)
                {
                    output.Append(string.Format("-Enhancements: {0}", string.Join(", ", this.Enhancements)));
                }
                else
                {
                    output.Append(string.Format("-Enhancements: {0}", "N/A"));
                }
            }
            return output.ToString();
        }
    }
}

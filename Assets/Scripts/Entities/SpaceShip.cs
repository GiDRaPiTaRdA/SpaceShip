using System;
using ToolKit;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class SpaceShip
    {
        #region Inputs
        public float TrustForce { get; set; }
        public float RertardForce { get; set; }
        public float TurnForce { get; set; }
        public float Stabelization { get; set; }
        public float Fuel { get; set; }
        public float HP { get; set; }
        public int Stars { get; set; }
        public float Consumption { get; set; }
        public float DestructTreshold { get; set; }
        #endregion

        #region Properties
        public float TurnConsumption { get { return Consumption * 0.3f; } }
        public float StabelizeConsumption { get { return Consumption * 0.1f; } }

        public bool AnyFuel { get { return Fuel > 0; } }

        public bool IsLocked { get; set; }
        public bool IsDestroyed { get; set; }

        public bool IsTrusting { get; private set; }
        public bool IsRetarding { get; private set; }
        public bool IsTurningLeft { get; private set; }
        public bool IsTurningRight { get; private set; }

        public bool CanAct { get { return this.AnyFuel && !this.IsLocked && !this.IsDestroyed; } }
        #endregion

        #region Events
        public event EventHandler<SpaceShipEventArgs> OnFire;

        public event EventHandler<SpaceShipEventArgs> OnTrust;
        public event EventHandler<SpaceShipEventArgs> OnRetard;

        public event EventHandler<SpaceShipEventArgs> OnTurn;

        public event EventHandler<SpaceShipEventArgs> OnStabelize;
        public event EventHandler<SpaceShipEventArgs> OnFuelExeeds;
        public event EventHandler<SpaceShipEventArgs> OnDestruct;
        #endregion

        public void Fire()
        {
            if (this.CanAct)
            {
                this.OnFire.SafeInvoke(this, new SpaceShipEventArgs());
            }
        }

        public void Trust(bool @do)
        {
            if (this.CanAct && @do)
            {
                this.IsTrusting = true;

                this.OnTrust.SafeInvoke(this, new SpaceShipEventArgs() { TrustForce = this.TrustForce });

                //FuelConsumption(this.TurnConsumption);
            }
            else
            {
                this.IsTrusting = false;
            }
        }

        public void Retard(bool @do)
        {
            if (this.CanAct && @do)
            {
                this.IsRetarding = true;

                this.OnRetard.SafeInvoke(this, new SpaceShipEventArgs() { RetardForce = this.RertardForce });

                //FuelConsumption(this.TurnConsumption);
            }
            else
            {
                this.IsRetarding = false;
            }
        }

        public void TurnLeft(bool @do)
        {
            if (CanAct && @do)
            {
                this.IsTurningLeft = true;

                this.OnTurn.SafeInvoke(this, new SpaceShipEventArgs() { TurnForce = this.TurnForce });
            }
            else
            {
                this.IsTurningLeft = false;
            }
        }

        public void TurnRight(bool @do)
        {
            if (CanAct && @do)
            {
                this.IsTurningRight = true;

                this.OnTurn.SafeInvoke(this, new SpaceShipEventArgs() { TurnForce = -this.TurnForce });
            }
            else
            {
                this.IsTurningRight = false;
            }
        }

        public void Stabelize(float force)
        {
            if (CanAct)
            {
                this.OnStabelize.SafeInvoke(this, new SpaceShipEventArgs() { StabelizingForce = force });
            }
        }

        public void Destroy()
        {
            this.OnDestruct.SafeInvoke(this, null);
        }

        public void OnCollisiion(float force)
        {
            Damage(force);
        }

        public void Damage(float force)
        {
            if (HP - force < 1)
            {
                HP = 0;
                Destroy();
            }
            else
            {
                HP -= force;
            }
        }

        #region Help

        public void FuelConsumption(float consumption)
        {
            if (this.CanAct)
            {
                if (this.Fuel > consumption)
                    this.Fuel -= consumption;
                else
                {
                    this.Fuel = 0;
                    OnFuelExeeds.SafeInvoke(this, null);
                }
            }
        }

        #endregion
    }
}


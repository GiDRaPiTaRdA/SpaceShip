﻿using System;
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
        public float TurnConsumption => this.Consumption * 0.3f;
        public float StabelizeConsumption => this.Consumption * 0.1f;
        public bool AnyFuel => this.Fuel > 0;
        public bool CanAct => this.AnyFuel && !this.IsLocked && !this.IsDestroyed;

        public bool IsLocked { get; set; }
        public bool IsDestroyed { get; set; }

        public bool IsTrusting { get; private set; }
        public bool IsRetarding { get; private set; }
        public bool IsTurningLeft { get; private set; }
        public bool IsTurningRight { get; private set; }
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
                this.OnFire?.Invoke(this, new SpaceShipEventArgs());
            }
        }

        public void Trust(bool @do)
        {
            if (this.CanAct && @do)
            {
                this.IsTrusting = true;

                this.OnTrust?.Invoke(this, new SpaceShipEventArgs() { TrustForce = this.TrustForce });
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

                this.OnRetard?.Invoke(this, new SpaceShipEventArgs() { RetardForce = this.RertardForce });

                //FuelConsumption(this.TurnConsumption);
            }
            else
            {
                this.IsRetarding = false;
            }
        }

        public void TurnLeft(bool @do)
        {
            if (this.CanAct && @do)
            {
                this.IsTurningLeft = true;

                this.OnTurn?.Invoke(this, new SpaceShipEventArgs() { TurnForce = this.TurnForce });
            }
            else
            {
                this.IsTurningLeft = false;
            }
        }

        public void TurnRight(bool @do)
        {
            if (this.CanAct && @do)
            {
                this.IsTurningRight = true;

                this.OnTurn?.Invoke(this, new SpaceShipEventArgs() { TurnForce = -this.TurnForce });
            }
            else
            {
                this.IsTurningRight = false;
            }
        }

        public void Stabelize(float force)
        {
            if (this.CanAct)
            {
                this.OnStabelize?.Invoke(this, new SpaceShipEventArgs() { StabelizingForce = force });
            }
        }

        public void Destroy()
        {
            this.OnDestruct?.Invoke(this, null);
        }

        public void OnCollisiion(float force)
        {
            this.Damage(force);
        }

        public void Damage(float force)
        {
            if (this.HP - force < 1)
            {
                this.HP = 0;
                this.Destroy();
            }
            else
            {
                this.HP -= force;
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
                    this.OnFuelExeeds?.Invoke(this, null);
                }
            }
        }

        #endregion
    }
}


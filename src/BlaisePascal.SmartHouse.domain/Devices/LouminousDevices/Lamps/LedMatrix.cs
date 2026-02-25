using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices;
using BlaisePascal.SmartHouse.Domain.Devices.LouminousDevices.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class LedMatrix : AbstractDevice
    {
        public AbstractLamp?[,] Matrix { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LedMatrix(Name name, int height, int width) : base(name)
        {
            if (height <= 0) throw new ArgumentException("Height must be greater than 0");
            if (width <= 0) throw new ArgumentException("Width must be greater than 0");

            Height = height;
            Width = width;
            Matrix = new AbstractLamp?[height, width];
        }

        public LedMatrix(Name name, Guid id)
            : base(name, id)
        {
            Height = Matrix.GetLength(0);
            Width = Matrix.GetLength(1);
        }

        public void AddLampInPosition(AbstractLamp lamp, int row, int column)
        {
            if (row < 0 || row >= Height || column < 0 || column >= Width)
                throw new IndexOutOfRangeException("Invalid position");

            if (Matrix[row, column] != null)
                throw new ArgumentException("Not available place");

            Matrix[row, column] = lamp;
            UpdateLastModified();
        }

        public void RemoveLamp(Name name)
        {
            if (name == null) throw new ArgumentException("Invalid name");

            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c]?.Name == name)
                    {
                        Matrix[r, c] = null;
                        UpdateLastModified();
                        return;
                    }
                }
            }
            throw new ArgumentException("No lamps with this name");
        }

        public void RemoveLamp(Guid id)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Id == id)
                    {
                        Matrix[r, c] = null;
                        UpdateLastModified();
                        return;
                    }
                }
            }
            throw new ArgumentException("No lamps with this guid");
        }

        public void RemoveLampInPosition(int row, int column)
        {
            if (row < 0 || row >= Height || column < 0 || column >= Width)
                throw new IndexOutOfRangeException("Invalid position");

            if (Matrix[row, column] != null)
            {
                Matrix[row, column] = null;
                UpdateLastModified();
            }
        }

        public override void TurnOn()
        {
            base.TurnOn();
            foreach (AbstractLamp i in Matrix)
            {
                if (i != null)
                {
                    i.TurnOn();
                }
            }
            UpdateLastModified();
        }

        public override void TurnOff()
        {
            base.TurnOff();
            foreach (AbstractLamp i in Matrix)
            {
                if (i != null)
                {
                    i.TurnOff();
                }
            }
            UpdateLastModified();
        }

        public void SwitchOnOneLamp(Guid id)
        {
            GetLamp(id).TurnOn();
            UpdateLastModified();
        }

        public void SwitchOnOneLamp(Name name)
        {
            GetLamp(name).TurnOn();
            UpdateLastModified();
        }

        public void SwitchOffOneLamp(Guid id)
        {
            GetLamp(id).TurnOff();
            UpdateLastModified();
        }

        public void SwitchOffOneLamp(Name name)
        {
            GetLamp(name).TurnOff();
            UpdateLastModified();
        }

        public void SetBrightness(Brightness newbrightness)
        {
            foreach (AbstractLamp lamp in Matrix)
            {
                if (lamp != null)
                    lamp.SetBrightness(newbrightness);
            }
            UpdateLastModified();
        }

        public void SetBrightnessOneLamp(Brightness newbrightness, Guid id)
        {
            GetLamp(id).SetBrightness(newbrightness);
            UpdateLastModified();
        }

        public void SetBrightnessOneLamp(Brightness newbrightness, Name name)
        {
            GetLamp(name).SetBrightness(newbrightness);
            UpdateLastModified();
        }

        public AbstractLamp FindLampWithMaxBrightness()
        {
            NotNullValidator();

            AbstractLamp? maxLamp = null;

            foreach (AbstractLamp l in Matrix)
            {
                if (l == null) continue;

                if (maxLamp == null || l.CurrentBrightness.Value > maxLamp.CurrentBrightness.Value)
                    maxLamp = l;
            }

            return maxLamp;
        }

        public AbstractLamp FindLampWithMinBrightness()
        {
            NotNullValidator();

            AbstractLamp minLamp = null;

            foreach (AbstractLamp l in Matrix)
            {
                if (l == null) continue;

                if (minLamp == null || l.CurrentBrightness.Value < minLamp.CurrentBrightness.Value)
                    minLamp = l;
            }

            return minLamp;
        }

        public void SetChessboardPattern()
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] == null) continue;

                    if ((r + c) % 2 == 0) Matrix[r, c].TurnOn();
                    else Matrix[r, c].TurnOff();
                }
            }
            UpdateLastModified();
        }

        private AbstractLamp GetLamp(Guid id)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c] != null && Matrix[r, c].Id == id)
                    {
                        return Matrix[r, c];
                    }
                }
            }
            throw new ArgumentException("No lamps with this guid");
        }

        private AbstractLamp GetLamp(Name name)
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < Width; c++)
                {
                    if (Matrix[r, c]?.Name == name)
                    {
                        return Matrix[r, c];
                    }
                }
            }
            throw new ArgumentException("No lamps with this name");
        }

        public void NotNullValidator()
        {
            foreach (var lamp in Matrix)
            {
                if (lamp != null)
                    return;
            }
            throw new InvalidOperationException("All the matrix positions are null");
        }
    }
}
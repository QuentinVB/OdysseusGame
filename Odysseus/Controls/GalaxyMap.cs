using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Odysseus.Core;

namespace Odysseus.Controls
{    
    public class GalaxyMap : DialBox
    {
        #region Fields

        private GameCore _core;

        private Button[] _destinations;

        #endregion

        #region Properties
        public Button[] Destinations { get => _destinations; set => _destinations = value; }
        public Texture2D GalaxyTexture { get; internal set; }
        public GameCore CoreAttached { get => _core; private set => _core = value; }
        public Vector2 Center { get => new Vector2(Box.X + Box.Width / 2, Box.Y + Box.Height / 2); }
        #endregion

        #region Methods
        public GalaxyMap(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle rectangle)
            : base(name, graphics, font, rectangle)
        {
            IsVisible = false;

            PenColour = Color.White;            
        }

        private Vector2 ConvertMapPositionToGlobal(Vector2 position)
        {
            return ConvertMapPositionToGlobal((int)position.X, (int)position.Y);
        }

        private Vector2 ConvertMapPositionToGlobal(int X, int Y)
        {
            return new Vector2(
                Center.X + (X / (float)CoreAttached.GalaxyWidth) * Box.Width,
                Center.Y + (Y / (float)CoreAttached.GalaxyHeight) * Box.Height
                );
        }

        public void AttachCore(GameCore core)
        {
            CoreAttached = core;
            Destinations = new Button[2];          
            CreateButton(0, _core.NextRight);
            CreateButton(1, _core.NextLeft);
        }

        private void CreateButton(int index,StellarSystem system)
        {
            var position = ConvertMapPositionToGlobal(system.X, system.Y);
            Destinations[index] = new Button(
                index.ToString(),
                Graphics,
                Font,
                new Rectangle((int)position.X, (int)position.Y, 80,64)
                )
            {
                Text = system.MapString,
                BGColour=Color.Transparent,
                PenColour=PenColour
            };
            Destinations[index].Click += Destination_Click;

        }

        private void Destination_Click(object sender, EventArgs e)
        {
            if(sender is Button buttonCliked)
            {           
                IsVisible = false;
                CoreAttached.PlayerShip.UpdateGameTurn();
                CoreAttached.WarpShipTo(int.Parse(buttonCliked.Name) == 0 ? _core.NextRight : _core.NextLeft);
                CoreAttached.GenerateNextDestinations();
                CreateButton(0, _core.NextRight);
                CreateButton(1, _core.NextLeft);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(Destinations!=null)
            {
                foreach (var component in Destinations)
                    component.Update(gameTime);
            }      
            
            CloseButton.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(IsVisible)
            {
                var colour = Color.White;

                spriteBatch.Draw(GalaxyTexture, Box, colour);

                if (CoreAttached != null)
                {
                        spriteBatch.DrawString(
                        Font,
                        $"*\n{CoreAttached.PlayerShip.Orbiting.MapString}",
                        ConvertMapPositionToGlobal(CoreAttached.PlayerShip.Orbiting.X, CoreAttached.PlayerShip.Orbiting.Y),
                        PenColour
                        );
                    if (Destinations != null)
                    {
                        foreach (var component in Destinations)
                        component.Draw(gameTime, spriteBatch);
                    }
                }  
            }   
            CloseButton.Draw(gameTime, spriteBatch);
        }
        #endregion
    }
   
}

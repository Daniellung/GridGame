using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GridGame
{
    
    class Space:Drawable
    {
        private Unit unit;
        private Boolean occupied;
        private Terrain terrain;
        private OverlayState overlayState;
        private (int, int) coordinates;

        private Texture2D moveTexture;
        private Texture2D rangeTexture;
        private Texture2D enemyTexture;

        public enum OverlayState
        {
            none,
            move,
            attack,
            enemy
        }

        public enum Terrain
        {
            Plains,
            Forest,
            River,
            Road,
            Hill,
            Mountain,
            Structure,
            StructureDestroyed
        }

        
        public Space(ContentManager Content, Vector2 position, (int, int) coords)
        {
            coordinates = coords;
            this.position = position;
            occupied = false;
            moveTexture = Content.Load<Texture2D>("OverlayMove");
            rangeTexture = Content.Load<Texture2D>("OverlayRange");
            enemyTexture = Content.Load<Texture2D>("OverlayEnemy");
            setOverlayState(OverlayState.none);
        }

        public (int, int) getCoordinates()
        {
            return coordinates;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if(overlayState != OverlayState.none)
            {
                base.Draw(spriteBatch, gameTime);
            }
            if(unit != null) unit.Draw(spriteBatch, gameTime);
        }

        public void addUnit(Unit unit)
        {
            this.unit = unit;
            occupied = true;
        }
        public void removeUnit() {
            this.unit = null;
            occupied = false;
        }

        public bool isOccupied()
        {
            return occupied;
        }

        public void setOverlayState(OverlayState state)
        {
            overlayState = state;
            switch (overlayState)
            {
                case (OverlayState.none):
                    myTexture = null;
                    break;
                case (OverlayState.move):
                    myTexture = moveTexture; 
                    break;
                case (OverlayState.attack):
                    myTexture = rangeTexture;
                    break;
                case (OverlayState.enemy):
                    myTexture = enemyTexture;
                    break;
            }
        }

        public Unit getUnit()
        {
            return unit;
        }
        public Vector2 getPosition()
        {
            return position;
        }
        public Terrain getTerrain()
        {
            return terrain;
        }
    }
}

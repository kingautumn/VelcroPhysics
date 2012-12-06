﻿#region Using System
using System;
using System.Text;
#endregion
#region Using XNA
using Microsoft.Xna.Framework;
#endregion
#region Using Farseer
using FarseerPhysics.Samples.Demos.Prefabs;
using FarseerPhysics.Samples.ScreenSystem;
#endregion

namespace FarseerPhysics.Samples.Demos
{
  internal class WebOfGooDemo : PhysicsDemoScreen
  {
    private Border _border;
    private WebOfGoo _webOfGoo;

    #region Demo description

    public override string GetTitle()
    {
      return "Advanced dynamics";
    }

    public override string GetDetails()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine("This demo shows a web made of distance joints. The joints are configured");
      sb.AppendLine("to break under stress, so that the web can be torn apart.");
      sb.AppendLine(string.Empty);
      sb.AppendLine("GamePad:");
      sb.AppendLine("  - Move cursor: Left thumbstick");
      sb.AppendLine("  - Grab object (beneath cursor): A button");
      sb.AppendLine("  - Drag grabbed object: Left thumbstick");
      sb.AppendLine("  - Exit to demo selection: Back button");
#if WINDOWS
      sb.AppendLine(string.Empty);
      sb.AppendLine("Keyboard:");
      sb.AppendLine("  - Exit to demo selection: Escape");
      sb.AppendLine(string.Empty);
      sb.AppendLine("Mouse");
      sb.AppendLine("  - Grab object (beneath cursor): Left click");
      sb.AppendLine("  - Drag grabbed object: Move mouse");
#endif
      return sb.ToString();
    }

    public override int GetIndex()
    {
      return 9;
    }

    #endregion

    public override void LoadContent()
    {
      base.LoadContent();

      World.Gravity = new Vector2(0, 9.82f);

      _border = new Border(World, Lines, Framework.GraphicsDevice);

      _webOfGoo = new WebOfGoo(World, Vector2.Zero, ConvertUnits.ToSimUnits(12), 5, 12);
    }

    public override void Draw(GameTime gameTime)
    {
      Sprites.Begin(0, null, null, null, null, null, Camera.View);
      _webOfGoo.Draw(Sprites);
      Sprites.End();

      _border.Draw(Camera.SimProjection, Camera.SimView);

      base.Draw(gameTime);
    }
  }
}
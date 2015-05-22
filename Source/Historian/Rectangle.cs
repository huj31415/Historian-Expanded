/**
 * This file is part of Historian.
 * 
 * Historian is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * Historian is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Historian. If not, see <http://www.gnu.org/licenses/>.
 **/
 
using UnityEngine;

namespace KSEA.Historian
{
    public class Rectangle : Element
    {
        private Color m_Color = Color.black;
        private Texture m_Texture = null;

        protected override void OnDraw(Rect bounds)
        {
            GUI.DrawTexture(bounds, m_Texture);
        }

        protected override void OnLoad(ConfigNode node)
        {
            m_Color = node.GetColor("Color", Color.black);

            int width = (int) (Screen.width * Size.x);
            int height = (int) (Screen.height * Size.y);

            var texture = new Texture2D(width, height);
            var pixels = texture.GetPixels();

            for (int i = 0; i < pixels.Length; ++i)
            {
                pixels[i] = m_Color;
            }

            texture.SetPixels(pixels);
            texture.Apply();

            m_Texture = texture;
        }
    }
}
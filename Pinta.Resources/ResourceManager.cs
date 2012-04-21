// 
// ResourceLoader.cs
//  
// Author:
//       Jonathan Pobst <monkey@jpobst.com>
// 
// Copyright (c) 2010 Jonathan Pobst
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Gdk;

namespace Pinta.Resources
{
	public static class ResourceLoader
	{
		public static Pixbuf GetIcon (string name, int size)
		{
            Pixbuf icon;

            try
            {
                // First see if it's a built-in gtk icon, like gtk-new
                if (Gtk.IconTheme.Default.HasIcon(name))
                {
                    icon = Gtk.IconTheme.Default.LoadIcon(name, size, Gtk.IconLookupFlags.UseBuiltin);
                }
                // Otherwise, get it from our embedded resources.
                else
                {
                    icon = Gdk.Pixbuf.LoadFromResource(name);
                }
            }
            // Ensure that we don't crash if an icon is missing for some reason.
            catch (Exception e)
            {
                System.Console.Error.WriteLine (e.Message);
                icon = Gtk.IconTheme.Default.LoadIcon (Gtk.Stock.MissingImage, size, Gtk.IconLookupFlags.UseBuiltin);
            }

            return icon;
		}
	}
}

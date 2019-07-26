// NClass - UML class diagram editor
// Copyright (C) 2006 Balázs Tihanyi
// 
// This program is free software; you can redistribute it and/or modify it under 
// the terms of the GNU General Public License as published by the Free Software 
// Foundation; either version 3 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT 
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS 
// FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace NClass.Translations
{
	public static class Texts
	{
		static DisplayLanguage language = DisplayLanguage.Default;
		static CultureInfo culture = CultureInfo.CurrentCulture;
		static ResourceManager manager = new ResourceManager(
			"NClass.Translations.Texts", Assembly.GetExecutingAssembly());

		public static event EventHandler LanguageChanged;

		public static DisplayLanguage Language
		{
			get
			{
				return language;
			}
			set
			{
				if (value != language) {
					switch (value) {
						case DisplayLanguage.English:
							culture = new CultureInfo("en");
							break;
						case DisplayLanguage.Hungarian:
							culture = new CultureInfo("hu");
							break;
						default:
							culture = CultureInfo.CurrentUICulture;
							break;
					}
					language = value;

					if (LanguageChanged != null)
						LanguageChanged(null, new EventArgs());
				}
			}
		}

		public static string GetText(string name)
		{
			string text = manager.GetString(name, culture);

			if (text == null)
				return "";
			else if (text.Contains("\\n"))
				return text.Replace("\\n", "\n");
			else
				return text;
		}

		public static string GetText(string name, object arg)
		{
			return string.Format(GetText(name), arg);
		}

		public static string GetText(string name, params object[] args)
		{
			return string.Format(GetText(name), args);
		}
	}
}

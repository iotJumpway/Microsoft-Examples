using IDC_Classifier_GUI.Classes;

using Windows.ApplicationModel;
using Windows.Graphics.Display;
using Windows.Media.Capture;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

/*
 * Invasive Ductal Carcinoma (IDC) Classification Using Computer Vision & IoT
 * ICML Intel AI DevJam Demo
 * Copyright (c) 2018 Adam Milton-Barker.
 * 
 * The MIT License (MIT)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR  * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

namespace IDC_Classifier_GUI
{
    /// <summary>
    /// IDC Classifier GUI homepage
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool isPreviewing;
        MediaCapture mediaCapture;
        DisplayRequest displayRequest = new DisplayRequest();
        Speech Speech = new Speech();

        public MainPage()
        {
            this.InitializeComponent();

            Speech.Speak("Welcome to the IDC Classifier GUI, please authenticate yourself using the camera.");
        }
    }
}

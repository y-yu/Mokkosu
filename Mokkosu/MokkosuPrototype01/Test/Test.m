﻿#=============================================================================
#! @file	FormSample01.m
#! @brief	First Form Sample
#! @author	kielnow
#=============================================================================

import "System.Windows.Forms.dll";
import "System.Drawing.dll";
import "MokkosuSupport.dll";

using System;
using System.Windows.Forms;
using System.Drawing;
using SystemFonts;
using MokkosuSupport;

#-----------------------------------------------------------------------------
# AFX
#-----------------------------------------------------------------------------
let intToFloat (i : Int) = call Convert::ToSingle(i);
let doubleToFloat (d : Double) = call Convert::ToSingle(d);
let floatToInt (f : {System.Single}) = call Convert::ToInt32(f);
let floatToDouble (f : {System.Single}) = call Convert::ToDouble(f);

#-----------------------------------------------------------------------------
# Global constants
#-----------------------------------------------------------------------------
let (screenWidth,screenHeight) = (800,600);
let fps = 60;
let fpsInv = 1000 / 60;
let title = "Mokkosu First Form Sample";
let font = new Font("Meiryo", intToFloat 80, sget FontStyle::Bold);

#-----------------------------------------------------------------------------
# Global states
#-----------------------------------------------------------------------------
let theta = ref 0.0;

#-----------------------------------------------------------------------------
# Create a new window
#-----------------------------------------------------------------------------
let form = new DoubleBufferedForm();

do form.set_ClientSize(new Size(screenWidth,screenHeight));
do form.set_SizeGripStyle(sget SizeGripStyle::Hide);
do form.set_FormBorderStyle(sget FormBorderStyle::FixedSingle);
do form.set_Text(title);

#-----------------------------------------------------------------------------
# Tick event
#-----------------------------------------------------------------------------
let evTick ((obj : {System.Object}), (e : {System.EventArgs})) =
  do theta := !theta +. pi *. 2.0 /. 180.0;
  in form.Invalidate();

let timer = new Timer();

do timer.set_Interval(fpsInv);
do timer.add_Tick(delegate EventHandler evTick);

#-----------------------------------------------------------------------------
# Paint event
#-----------------------------------------------------------------------------
let evPaint ((obj : {System.Object}), (e : {PaintEventArgs})) =
  let g = e.get_Graphics() in
  let c = 128 + call Convert::ToInt32(127.0 *. sin !theta) in
  let clearColor = call Color::FromArgb(255,0,c,255) in
  let textColor = call Color::FromArgb(255,0,255-c,255) in
  let brush = new SolidBrush(textColor) in
  let text = "Mokkosu" in
  let textSize = g.MeasureString(text,font) in
  let (tw,th) = (floatToInt textSize.get_Width(),floatToInt textSize.get_Height()) in
  let (tx,ty) = (intToFloat ((screenWidth-tw)/2),intToFloat ((screenHeight-th)/2)) in
  do g.Clear(clearColor);
     g.set_SmoothingMode(sget Drawing2D.SmoothingMode::AntiAlias);
     g.set_TextRenderingHint(sget Text.TextRenderingHint::AntiAlias);
     g.DrawString(text,font,brush,new PointF(tx,ty));
  in ();
  

do form.add_Paint(delegate PaintEventHandler evPaint);

#-----------------------------------------------------------------------------
# Entry point
#-----------------------------------------------------------------------------
do timer.Start();
do form.ShowDialog();

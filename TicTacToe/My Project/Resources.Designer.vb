﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("TicTacToe.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property bgmusic() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("bgmusic", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to B5CS2017.
        '''</summary>
        Friend ReadOnly Property Cheat_Code() As String
            Get
                Return ResourceManager.GetString("Cheat_Code", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property click() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("click", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property DL() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DL", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property O() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("O", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property point() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("point", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Public Class Form1
        '''    Dim TurnC As Integer &apos;La count des tours
        '''    Dim Turn As Integer &apos;A qui la tour
        '''    Dim P1 As Integer &apos;La valeur du top-left carree
        '''    Dim P2 As Integer &apos;La valeur du top-mid carree
        '''    Dim P3 As Integer &apos;La valeur du top-right carree
        '''    Dim P4 As Integer &apos;La valeur du gauche-centre carree
        '''    Dim P5 As Integer &apos;La valeur du centre carree
        '''    Dim P6 As Integer &apos;La valeur du droite-centre carree
        '''    Dim P7 As Integer &apos;La valeur du bottom-left carree
        '''    Dim P8 As Integer &apos;L [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property TicTacToe_Code() As String
            Get
                Return ResourceManager.GetString("TicTacToe_Code", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property X() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("X", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Poc.Foxit.Api.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceHTMLs {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceHTMLs() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Poc.Foxit.Api.Resources.ResourceHTMLs", typeof(ResourceHTMLs).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        ///&lt;html&gt;
        ///
        ///&lt;head&gt;
        ///  &lt;meta charset=&quot;utf-8&quot; /&gt;
        ///  &lt;title&gt;&lt;/title&gt;
        ///
        ///  &lt;style&gt;
        ///    html {
        ///      height: 100%;
        ///      width: 100vw;
        ///      margin: 0;
        ///    }
        ///
        ///    body {
        ///      padding: 10px 50px 50px 50px;
        ///      font-weight: normal;
        ///      font-family: &quot;Roboto&quot;, sans-serif;
        ///      font-size: 16px;
        ///      font-weight: normal;
        ///      margin-bottom: 200px;
        ///      color: #363636;
        ///    }
        ///	
        ///	b{ 
        ///	 font-weight: bold !important; 
        ///	} 
        ///
        ///    header {
        ///      margin-top: 10px;
        ///    }
        ///
        ///    head [rest of string was truncated]&quot;;.
        /// </summary>
        public static string TestHTML {
            get {
                return ResourceManager.GetString("TestHTML", resourceCulture);
            }
        }
    }
}
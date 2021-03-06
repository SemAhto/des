﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TecWare.DE.Server.Configuration
{
	#region -- class DEConfigurationSchemaAttribute -------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public class DEConfigurationSchemaAttribute : Attribute
	{
		/// <summary>Marks a manifest-resource as a schema extension.</summary>
		/// <param name="baseType"></param>
		/// <param name="resourceId"></param>
		public DEConfigurationSchemaAttribute(Type baseType, string resourceId)
		{
			this.BaseType = baseType;
			this.ResourceId = resourceId;
		} // ctor

		public Type BaseType { get; }
		public string ResourceId { get; }
	} // class DEConfigurationSchemaAttribute

	#endregion

	#region -- interface IDEConfigurationAnnotated --------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public interface IDEConfigurationAnnotated
	{
		/// <summary>Annotated documentation.</summary>
		string Documentation { get; }
	} // interface IDEConfigurationAnnotated

	#endregion

	#region -- interface IDEConfigurationAttribute --------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public interface IDEConfigurationAttribute : IDEConfigurationAnnotated
	{
		/// <summary>Name of the element.</summary>
		XName Name { get; }
		/// <summary>Simple type of the element.</summary>
		Type Type { get; }
		/// <summary>Xml-Type-Name</summary>
		string TypeName { get; }
		/// <summary>Returns the default of the attribute.</summary>
		string DefaultValue { get; }

		/// <summary>Is the attribute in element notation.</summary>
		bool IsElement { get; }
		/// <summary>Is the element a xml-list.</summary>
		bool IsList { get; }
		/// <summary>Is this attribute a primary key.</summary>
		bool IsPrimaryKey { get; }
		/// <summary>There can be one or more member</summary>
		int MinOccurs { get; }
		/// <summary>There can be one or more member</summary>
		int MaxOccurs { get; }
	} // interface IDEConfigurationAttribute

	#endregion

	#region -- interface IDEConfigurationElement ----------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public interface IDEConfigurationElement : IDEConfigurationAnnotated
	{
		/// <summary>Name of the element.</summary>
		XName Name { get; }

		/// <summary>Enumerates the attributes.</summary>
		/// <returns></returns>
		IEnumerable<IDEConfigurationAttribute> GetAttributes();
		/// <summary></summary>
		/// <returns></returns>
		IEnumerable<IDEConfigurationElement> GetElements();

		/// <summary>Class Type</summary>
		Type ClassType { get; }
		/// <summary>There can be one or more member</summary>
		int MinOccurs { get; }
		/// <summary>There can be one or more member</summary>
		int MaxOccurs { get; }
	} // interface IDEConfigurationElement

	#endregion

	#region -- interface IDEConfigurationService ----------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public interface IDEConfigurationService
	{
		/// <summary>Returns the definition for the current attribute.</summary>
		/// <param name="attribute">element or attribute</param>
		/// <returns></returns>
		IDEConfigurationAttribute GetAttribute(XObject attribute);

		/// <summary>Path to the main configuration file.</summary>
		string ConfigurationFile { get; }
		/// <summary>Timestamp for the configuration file.</summary>
		DateTime ConfigurationStamp { get; }

		/// <summary>Path to all configuration files, of the last successful parse process.</summary>
		IEnumerable<string> ConfigurationFiles { get; }

		/// <summary>Returns the configuration description for the xml-element</summary>
		/// <param name="element"></param>
		/// <returns></returns>
		IDEConfigurationElement this[XName name] { get; }
	} // interface IDEConfigurationService

	#endregion

	#region -- class DEConfigurationConstants -------------------------------------------

	///////////////////////////////////////////////////////////////////////////////
	/// <summary></summary>
	public static class DEConfigurationConstants
	{
		public static readonly XNamespace MainNamespace = "http://tecware-gmbh.de/dev/des/2014";

		public static readonly XName xnDes = MainNamespace + "des";
		public static readonly XName xnFragment = MainNamespace + "fragment";
		public static readonly XName xnInclude = MainNamespace + "include";

		public static readonly XName xnServer = MainNamespace + "server";
		public static readonly XName xnServerResolve = MainNamespace + "resolve";
		public static readonly XName xnServerLoad = MainNamespace + "load";
		public static readonly XName xnServerExtent = MainNamespace + "extent";
		public static readonly XName xnServerDependOnServer = MainNamespace + "dependonservice";
		public static readonly XName xnServerSecurityGroup = MainNamespace + "securitygroup";

		public static readonly XName xnHttp = MainNamespace + "http";
		public static readonly XName xnHttpPrefix = MainNamespace + "prefix";
		public static readonly XName xnHttpAccess = MainNamespace + "access";
		public static readonly XName xnHttpMime = MainNamespace + "mime";
		public static readonly XName xnHttpBasicUser = MainNamespace + "basicuser";
		public static readonly XName xnHttpNtmlUser = MainNamespace + "ntmluser";

		public static readonly XName xnCron = MainNamespace + "cron";
		public static readonly XName xnCronRunAfter = MainNamespace + "runafter";
		public static readonly XName xnLuaEngine = MainNamespace + "luaengine";
		public static readonly XName xnLuaScript = MainNamespace + "script";
		public static readonly XName xnServerTcp = MainNamespace + "serverTcp";

		public static readonly XName xnLog = MainNamespace + "log";
		public static readonly XName xnVariable = MainNamespace + "variable";
		public static readonly XName xnGroup = MainNamespace + "group";
		public static readonly XName xnFiles = MainNamespace + "files";
		public static readonly XName xnResources = MainNamespace + "resources";
		public static readonly XName xnAlternativeRoot = MainNamespace + "alternativeRoot";
		public static readonly XName xnMimeDef = MainNamespace + "mimeDef";
		public static readonly XName xnSecurityDef = MainNamespace + "securityDef";

		public static readonly XName xnLuaCronGroup = MainNamespace + "cronGroup";
		public static readonly XName xnLuaCronBatch = MainNamespace + "cronBatch";
		public static readonly XName xnLuaCronJob = MainNamespace + "luaCronJob";
		public static readonly XName xnLuaProcess = MainNamespace + "process";
		public static readonly XName xnDirectoryListener = MainNamespace + "directoryListener";

		public static readonly XName xnLuaConfigItem = MainNamespace + "configItem";
		public static readonly XName xnLuaConfigLogItem = MainNamespace + "configLogItem";
	} // class DEConfigurationConstants

	#endregion
}

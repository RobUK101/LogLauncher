﻿// Log Launcher

/// Feel free to re-use concepts and actual code from this project, attribution and make public the source codeif you make something similiar from these here bones is all I ask

// Robert Marshall - 2017 - Enterprise Mobility MVP

// A fully compiled (release profile) version of the tool wrapped in MSI form can be obtained from the TechNet Gallery - https://gallery.technet.microsoft.com/LogLauncher-61ba5c99

// Ribbon capability sourced from https://www.codeproject.com/Articles/364272/Easily-Add-a-Ribbon-into-a-WinForms-Application-Cs,
// Thanks to KoglTH, toATwork, adriancs and Michael Spradlin and all those that helped to make the ribbon available, great work!

// Zip capabilities sourced from https://dotnetzip.codeplex.com - Provided excellent ZIP integration into LogLauncher
// Thanks Jaans and team for making DotNetZIP! (https://www.codeplex.com/site/users/view/Jaans)

// To compile this project you will need to place System.Windows.Forms.Ribbon35.dll and Ionic.Zip.dll placed in the projects resource folder

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;
using System.Linq;
using Ionic.Zip;

namespace LogLauncher
{
    public partial class Form1 : Form
    {
        // ConfigMgr/SCCM Log Hints

        string[,] logHints = new string[,] { { @"CAS.log", @"Content Access service. Maintains the local package cache on the client." }, { @"Ccm32BitLauncher.log", @"Records actions for starting applications on the client marked as 'run as 32bit'." }, { @"CcmEval.log", @"Records Configuration Manager client status evaluation activities and details for components that are required by the Configuration Manager client." }, { @"CcmEvalTask.log", @"Records the Configuration Manager client status evaluation activities that are initiated by the evaluation scheduled task." }, { @"CcmExec.log", @"Records activities of the client and the SMS Agent Host service. This log file also includes information about enabling and disabling wake-up proxy." }, { @"CcmMessaging.log", @"Records activities related to communications between the client and management points." }, { @"CCMNotificationAgent.log", @"Records activities related to client notification operations." }, { @"Ccmperf.log", @"Records activities related to the maintenance and capture of data related to client performance counters." }, { @"CcmRestart.log", @"Records client service restart activity." }, { @"CCMSDKProvider.log", @"Records activities for the client SDK interfaces." }, { @"CertificateMaintenance.log", @"Maintains certificates for Active Directory Domain Services and management points." }, { @"CIDownloader.log", @"Records details about configuration item definition downloads." }, { @"CITaskMgr.log", @"Records tasks that are initiated for each application and deployment type, such as content download or install or uninstall actions." }, { @"ClientAuth.log", @"Records the signing and authentication activity for the client." }, { @"ClientIDManagerStartup.log", @"Creates and maintains the client GUID and identifies tasks performed during client registration and assignment." }, { @"ClientLocation.log", @"Records tasks that are related to client site assignment." }, { @"CMHttpsReadiness.log", @"Records the results of running the Configuration Manager HTTPS Readiness Assessment Tool. This tool checks whether computers have a PKI client authentication certificate that can be used for Configuration Manager." }, { @"CmRcService.log", @"Records information for the remote control service." }, { @"ContentTransferManager.log", @"Schedules the Background Intelligent Transfer Service (BITS) or the Server Message Block (SMB) to download or to access packages." }, { @"DataTransferService.log", @"Records all BITS communication for policy or package access." }, { @"EndpointProtectionAgent", @"Records information about the installation of the Endpoint Protection client and the application of antimalware policy to that client." }, { @"execmgr.log", @"Records details about packages and task sequences that run on the client." }, { @"ExpressionSolver.log", @"Records details about enhanced detection methods that are used when verbose or debug logging is enabled." }, { @"ExternalEventAgent.log", @"Records the history of Endpoint Protection malware detection and events related to client status." }, { @"FileBITS.log", @"Records all SMB package access tasks." }, { @"FileSystemFile.log", @"Records the activity of the Windows Management Instrumentation (WMI) provider for software inventory and file collection." }, { @"FSPStateMessage.log", @"Records the activity for state messages that are sent to the fallback status point by the client." }, { @"InternetProxy.log", @"Records the network proxy configuration and usage activity for the client." }, { @"InventoryAgent.log", @"Records activities of hardware inventory, software inventory, and heartbeat discovery actions on the client." }, { @"LocationCache.log", @"Records the activity for location cache usage and maintenance for the client." }, { @"LocationServices.log", @"Records the client activity for locating management points, software update points, and distribution points." }, { @"MaintenanceCoordinator.log", @"Records the activity for general maintenance task activity for the client." }, { @"Mifprovider.log", @"Records the activity of the WMI provider for .MIF files." }, { @"mtrmgr.log", @"Monitors all software metering processes." }, { @"PolicyAgent.log", @"Records requests for policies made by using the Data Transfer service." }, { @"PolicyAgentProvider.log", @"Records policy changes." }, { @"PolicyEvaluator.log", @"Records details about the evaluation of policies on client computers, including policies from software updates." }, { @"PolicyPlatformClient.log", @"Records the process of remediation and compliance for all providers located in %Program Files%\Microsoft Policy Platform, except the file provider." }, { @"PolicySdk.log", @"Records activities for policy system SDK interfaces." }, { @"Pwrmgmt.log", @"Records information about enabling or disabling and configuring the wake-up proxy client settings." }, { @"PwrProvider.log", @"Records the activities of the power management provider (PWRInvProvider) hosted in the Windows Management Instrumentation (WMI) service. On all supported versions of Windows, the provider enumerates the current settings on computers during hardware inventory and applies power plan settings." }, { @"SCClient_<domain>@<username>_1.log", @"Records the activity in Software Center for the specified user on the client computer." }, { @"SCClient_<domain>@<username>_2.log", @"Records the historical activity in Software Center for the specified user on the client computer." }, { @"Scheduler.log", @"Records activities of scheduled tasks for all client operations." }, { @"SCNotify_<domain>@<username>_1.log", @"Records the activity for notifying users about software for the specified user." }, { @"SCNotify_<domain>@<username>_1-<date_time>.log", @"Records the historical information for notifying users about software for the specified user." }, { @"setuppolicyevaluator.log", @"Records configuration and inventory policy creation in WMI." }, { @"SleepAgent_<domain>@<@SYSTEM_0.log", @"Main log file for wake-up proxy." }, { @"smscliui.log", @"Records usage of the Configuration Manager client in Control Panel." }, { @"SrcUpdateMgr.log", @"Records activity for installed Windows Installer applications that are updated with current distribution point source locations." }, { @"StatusAgent.log", @"Records status messages that are created by the client components." }, { @"SWMTRReportGen.log", @"Generates a usage data report that is collected by the metering agent. This data is logged in Mtrmgr.log." }, { @"UserAffinity.log", @"Records details about user device affinity." }, { @"VirtualApp.log", @"Records information specific to the evaluation of App-V deployment types." }, { @"Wedmtrace.log", @"Records operations related to write filters on Windows Embedded clients." }, { @"wakeprxy-install.log", @"Records installation information when clients receive the client setting option to enable wake-up proxy." }, { @"wakeprxy-uninstall.log", @"Records information about uninstalling wake-up proxy when clients receive the client setting option to disable wake-up proxy, if wake-up proxy was previously enabled." }, { @"ccmsetup.log", @"Records ccmsetup tasks for client setup, client upgrade, and client removal. Can be used to troubleshoot client installation problems." }, { @"ccmsetup-ccmeval.log", @"Records ccmsetup tasks for client status and remediation." }, { @"CcmRepair.log", @"Records the repair activities of the client agent." }, { @"client.msi.log", @"Records setup tasks performed by client.msi. Can be used to troubleshoot client installation or removal problems." }, { @"adctrl.log", @"Records enrollment processing activity." }, { @"ADForestDisc.log", @"Records Active Directory Forest Discovery actions." }, { @"ADService.log", @"Records account creation and security group details in Active Directory." }, { @"adsgdis.log", @"Records Active Directory Group Discovery actions." }, { @"adsysdis.log", @"Records Active Directory System Discovery actions." }, { @"adusrdis.log", @"Records Active Directory User Discovery actions." }, { @"ccm.log", @"Records client push installation activities." }, { @"CertMgr.log", @"Records the certificate activities for intra-site communications." }, { @"chmgr.log", @"Records activities of the client health manager." }, { @"Cidm.log", @"Records changes to the client settings by the Client Install Data Manager (CIDM)." }, { @"colleval.log", @"Records details about when collections are created, changed, and deleted by the Collection Evaluator." }, { @"compmon.log", @"Records the status of component threads monitored for the site server." }, { @"compsumm.log", @"Records Component Status Summarizer tasks." }, { @"ComRegSetup.log", @"Records the initial installation of COM registration results for a site server." }, { @"dataldr.log", @"Records information about the processing of Management Information Format (MIF) files and hardware inventory in the Configuration Manager database." }, { @"ddm.log", @"Records activities of the discovery data manager." }, { @"despool.log", @"Records incoming site-to-site communication transfers." }, { @"distmgr.log", @"Records details about package creation, compression, delta replication, and information updates." }, { @"EPCtrlMgr.log", @"Records information about the synchronization of malware threat information from the Endpoint Protection site system role server into the Configuration Manager database." }, { @"EPMgr.log", @"Records the status of the Endpoint Protection site system role." }, { @"EPSetup.log", @"Provides information about the installation of the Endpoint Protection site system role." }, { @"EnrollSrv.log", @"Records activities of the enrollment service process." }, { @"EnrollWeb.log", @"Records activities of the enrollment website process." }, { @"fspmgr.log", @"Records activities of the fallback status point site system role." }, { @"hman.log", @"Records information about site configuration changes, and the publishing of site information in Active Directory Domain Services." }, { @"Inboxast.log", @"Records the files that are moved from the management point to the corresponding INBOXES folder on the site server." }, { @"inboxmgr.log", @"Records file transfer activities between inbox folders." }, { @"inboxmon.log", @"Records the processing of inbox files and performance counter updates." }, { @"invproc.log", @"Records the forwarding of MIF files from a secondary site to its parent site." }, { @"migmctrl.log", @"Records information for Migration actions involving migration jobs, shared distribution points, and distribution point upgrades. The top-level site in the System Center 2012 Configuration Manager hierarchy, and each child primary site." }, { @"mpcontrol.log", @"Records the registration of the management point with WINS. Records the availability of the management point every 10 minutes." }, { @"mpfdm.log", @"Records the actions of the management point component that moves client files to the corresponding INBOXES folder on the site server." }, { @"mpMSI.log", @"Records details of about the management point installation." }, { @"MPSetup.log", @"Records the management point installation wrapper process." }, { @"netdisc.log", @"Records Network Discovery actions." }, { @"ntsvrdis.log", @"Records the discovery activity of site system servers." }, { @"Objreplmgr", @"Records the processing of object change notifications for replication." }, { @"offermgr.log", @"Records advertisement updates." }, { @"offersum.log", @"Records the summarization of deployment status messages." }, { @"OfflineServicingMgr.log", @"Records the activities of applying updates to operating system image files." }, { @"outboxmon.log", @"Records the processing of outbox files and performance counter updates." }, { @"PerfSetup.log", @"Records the results of the installation of performance counters." }, { @"PkgXferMgr.log", @"Records the actions of the SMS Executive component that is responsible for sending content from a primary site to a remote distribution point." }, { @"policypv.log", @"Records updates to the client policies to reflect changes to client settings or deployments." }, { @"rcmctrl.log", @"Records the activities of database replication between sites in the hierarchy." }, { @"replmgr.log", @"Records the replication of files between the site server components and the Scheduler component." }, { @"ResourceExplorer.log", @"Records errors, warnings, and information about running the Resource Explorer." }, { @"ruleengine.log", @"Records details about automatic deployment rules for the identification, content download, and software update group and deployment creation." }, { @"schedule.log", @"Records details about site-to-site job and file replication." }, { @"sender.log", @"Records the files that transfer by file-based replication between sites." }, { @"sinvproc.log", @"Records information about the processing of software inventory data to the site database." }, { @"sitecomp.log", @"Records details about the maintenance of the installed site components on all site system servers in the site." }, { @"sitectrl.log", @"Records site setting changes made to site control objects in the database." }, { @"sitestat.log", @"Records the availability and disk space monitoring process of all site systems." }, { @"SmsAdminUI.log", @"Records Configuration Manager console activity." }, { @"SMSAWEBSVCSetup.log", @"Records the installation activities of the Application Catalog web service." }, { @"smsbkup.log", @"Records output from the site backup process." }, { @"smsdbmon.log", @"Records database changes." }, { @"SMSENROLLSRVSetup.log", @"Records the installation activities of the enrollment web service." }, { @"SMSENROLLWEBSetup.log", @"Records the installation activities of the enrollment website." }, { @"smsexec.log", @"Records the processing of all site server component threads." }, { @"SMSFSPSetup.log", @"Records messages generated by the installation of a fallback status point." }, { @"SMSPORTALWEBSetup.log", @"Records the installation activities of the Application Catalog website." }, { @"SMSProv.log", @"Records WMI provider access to the site database." }, { @"srsrpMSI.log", @"Records detailed results of the reporting point installation process from the MSI output." }, { @"srsrpsetup.log", @"Records results of the reporting point installation process." }, { @"statesys.log", @"Records the processing of state system messages." }, { @"statmgr.log", @"Records the writing of all status messages to the database." }, { @"swmproc.log", @"Records the processing of metering files and settings." }, { @"ConfigMgrPrereq.log", @"Records pre-requisite component evaluation and installation activities." }, { @"ConfigMgrSetup.log", @"Records detailed output from site server setup." }, { @"ConfigMgrSetupWizard.log", @"Records information related to activity in the Setup wizard." }, { @"SMS_BOOTSTRAP.log", @"Records information about the progress of launching the secondary site installation process. Details of the actual setup process are contained in ConfigMgrSetup.log." }, { @"smstsvc.log", @"Records information about the installation, use, and removal of a Windows service that is used to test network connectivity and permissions between servers, using the computer account of the server initiating the connection." }, { @"FspIsapi", @"Records details about communications to the fallback status point from mobile device legacy clients and client computers." }, { @"fspMSI.log", @"Records messages generated by the installation of a fallback status point." }, { @"fspmgr.log", @"Records activities of the fallback status point site system role." }, { @"CcmIsapi.log", @"Records client messaging activity on the endpoint." }, { @"MP_CliReg.log", @"Records the client registration activity processed by the management point." }, { @"MP_Ddr.log", @"Records the conversion of XML.ddr records from clients, and copies them to the site server." }, { @"MP_Framework.log", @"Records the activities of the core management point and client framework components." }, { @"MP_GetAuth.log", @"Records client authorization activity." }, { @"MP_GetPolicy.log", @"Records policy request activity from client computers." }, { @"MP_Hinv.log", @"Records details about the conversion of XML hardware inventory records from clients and the copy of those files to the site server." }, { @"MP_Location.log", @"Records location request and reply activity from clients." }, { @"MP_OOBMgr.log", @"Records the management point activities related to receiving OTP from a client." }, { @"MP_Policy.log", @"Records policy communication." }, { @"MP_Relay.log", @"Records the transfer of files that are collected from the client." }, { @"MP_Retry.log", @"Records the hardware inventory retry processes." }, { @"MP_Sinv.log", @"Records details about the conversion of XML software inventory records from clients and the copy of those files to the site server." }, { @"MP_SinvCollFile.log", @"Records details about file collection." }, { @"MP_Status.log", @"Records details about the conversion of XML.svf status message files from clients and the copy of those files to the site server." }, { @"mpcontrol.log", @"Records the registration of the management point with WINS. Records the availability of the management point every 10 minutes." }, { @"mpfdm.log", @"Records the actions of the management point component that moves client files to the corresponding INBOXES folder on the site server." }, { @"mpMSI.log", @"Records details of about the management point installation." }, { @"MPSetup.log", @"Records the management point installation wrapper process." }, { @"objreplmgr.log", @"Records details about the replication of software updates notification files from a parent to child sites." }, { @"PatchDownloader.log", @"Records details about the process of downloading software updates from the update source to the download destination on the site server." }, { @"ruleengine.log", @"Records details about automatic deployment rules for the identification, content download, and software update group and deployment creation." }, { @"SUPSetup.log", @"Records details about the software update point installation. When the software update point installation completes, Installation was successful is written to this log file." }, { @"WCM.log", @"Records details about the software update point configuration and connections to the Windows Server Update Services (WSUS) server for subscribed update categories, classifications, and languages." }, { @"WSUSCtrl.log", @"Records details about the configuration, database connectivity, and health of the WSUS server for the site." }, { @"wsyncmgr.log", @"Records details about the software updates synchronization process." }, { @"WUSSyncXML.log", @"Records details about the Inventory Tool for the Microsoft Updates synchronization process." }, { @"AppIntentEval.log", @"Records details about the current and intended state of applications, their applicability, whether requirements were met, deployment types, and dependencies." }, { @"AppDiscovery.log", @"Records details about the discovery or detection of applications on client computers. " }, { @"AppEnforce.log", @"Records details about enforcement actions (install and uninstall) taken for applications on the client." }, { @"awebsctl.log", @"Records the monitoring activities for the Application Catalog web service point site system role." }, { @"awebsvcMSI.log", @"Records detailed installation information for the Application Catalog web service point site system role." }, { @"Ccmsdkprovider.log", @"Records the activities of the application management SDK." }, { @"colleval.log", @"Records details about when collections are created, changed, and deleted by the Collection Evaluator." }, { @"ConfigMgrSoftwareCatalog.log", @"Records the activity of the Application Catalog, which includes its use of Silverlight." }, { @"portlctl.log", @"Records the monitoring activities for the Application Catalog website point site system role." }, { @"portlwebMSI.log", @"Records the MSI installation activity for the Application Catalog website role." }, { @"PrestageContent.log", @"Records the details about the use of the ExtractContent.exe tool on a remote prestaged distribution point. This tool extracts content that has been exported to a file." }, { @"ServicePortalWebService.log", @"Records the activity of the Application Catalog web service." }, { @"ServicePortalWebSite.log", @"Records the activity of the Application Catalog website." }, { @"SMSdpmon.log", @"Records details about the distribution point health monitoring scheduled task that is configured on a distribution point." }, { @"SoftwareCatalogUpdateEndpoint.log", @"Records the activities for managing the URL for the Application Catalog shown in Software Center." }, { @"SoftwareCenterSystemTasks.log", @"Records the activities for Software Center prerequisite component validation." }, { @"colleval.log", @"Records details about when collections are created, changed, and deleted by the Collection Evaluator." }, { @"execmgr.log", @"Records details about packages and task sequences that run." }, { @"AssetAdvisor.log", @"Records the activities of Asset Intelligence inventory actions." }, { @"aikbmgr.log", @"Records details about the processing of XML files from the inbox for updating the Asset Intelligence catalog." }, { @"AIUpdateSvc.log", @"Records the interaction of the Asset Intelligence synchronization point with SCO (System Center Online), the online web service." }, { @"AIUSMSI.log", @"Records details about the installation of Asset Intelligence synchronization point site system role." }, { @"AIUSSetup.log", @"Records details about the installation of Asset Intelligence synchronization point site system role." }, { @"ManagedProvider.log", @"Records details about discovering software with an associated software identification tag. Also records activities relating to hardware inventory." }, { @"MVLSImport.log", @"Records details about the processing of imported licensing files." }, { @"ConfigMgrSetup.log", @"Records information about setup and recovery tasks when Configuration Manager recovers a site from backup." }, { @"Smsbkup.log", @"Records details about the site backup activity." }, { @"smssqlbkup.log", @"Records output from the site database backup process when SQL Server is installed on a different server than the site server." }, { @"Smswriter.log", @"Records information about the state of the Configuration Manager VSS writer that is used by the backup process." }, { @"Crp.log", @"Records the enrollment activities." }, { @"Crpctrl.log", @"Records the operational health of the certificate registration point." }, { @"Crpsetup.log", @"Records details about the installation and configuration of the certificate registration point." }, { @"Crpmsi.log", @"Records details about the installation and configuration of the certificate registration point." }, { @"NDESPlugin.log", @"Records the challenge verification and certificate enrollment activities." }, { @"bgbmgr.log", @"Records details about the activities of the site server relating to client notification tasks and processing online and task status files." }, { @"BGBServer.log", @"Records the activities of the notification server such as client-server communications and pushing tasks to clients. Also records information about online and task status files generation to be sent to the site server." }, { @"BgbSetup.log", @"Records the activities of the notification server installation wrapper process during installation and uninstall." }, { @"bgbisapiMSI.log", @"Records details about the notification server installation and uninstall." }, { @"BgbHttpProxy.log", @"Records the activities of the notification HTTP proxy as it relays the messages of clients using HTTP to and from the notification server." }, { @"CcmNotificationAgent.log", @"Records the activities of the notification agent such as client-server communication and information about tasks received and dispatched to other client agents." }, { @"CIAgent.log", @"Records details about the process of remediation and compliance for compliance settings, software updates, and application management." }, { @"CITaskManager.log", @"Records information about configuration item task scheduling." }, { @"DCMAgent.log", @"Records high-level information about the evaluation, conflict reporting, and remediation of configuration items and applications." }, { @"DCMReporting.log", @"Records information about reporting policy platform results into state messages for configuration items." }, { @"DcmWmiProvider.log", @"Records information about reading configuration item synclets from Windows Management Instrumentation (WMI)." }, { @"ConfigMgrAdminUISetup.log", @"Records the installation of the Configuration Manager console." }, { @"SmsAdminUI.log", @"Records information about the operation of the Configuration Manager console." }, { @"Smsprov.log", @"Records activities performed by the SMS Provider. Configuration Manager console activities use the SMS provider." }, { @"CloudMgr.log", @"Records details about the provisioning of content, collecting storage and bandwidth statistics, and administrator initiated actions to stop or start the cloud service that runs a cloud-based distribution point." }, { @"For System Center 2012 Configuration Manager SP1 and later:", @"Records all BITS communication for policy or package access. This log is also used for content management by pull-distribution points." }, { @"DataTransferService.log", @"" }, { @"For System Center 2012 Configuration Manager SP1 and later:", @"Records details about content that the pull-distribution point transfers from source distribution points." }, { @"PullDP.log", @"" }, { @"PrestageContent.log", @"Records the details about the use of the ExtractContent.exe tool on a remote prestaged distribution point. This tool extracts content that has been exported to a file." }, { @"SMSdpmon.log", @"Records details about the distribution point health monitoring scheduled task that are configured on a distribution point." }, { @"smsdpprov.log", @"Records details about the extraction of compressed files received from a primary site. This log is generated by the WMI Provider of the remote distribution point." }, { @"adsgdis.log", @"Records Active Directory Security Group Discovery actions." }, { @"adsysdis.log", @"Records Active Directory System Discovery actions." }, { @"adusrdis.log", @"Records Active Directory User Discovery actions." }, { @"ADForestDisc.Log", @"Records Active Directory Forest Discovery actions." }, { @"ddm.log", @"Records activities of the discovery data manager." }, { @"InventoryAgent.log", @"Records activities of hardware inventory, software inventory, and heartbeat discovery actions on the client." }, { @"netdisc.log", @"Records Network Discovery actions." }, { @"EndpointProtectionAgent.log", @"Records details about the installation of the Endpoint Protection client and the application of antimalware policy to that client." }, { @"EPCtrlMgr.log", @"Records details about the synchronization of malware threat information from the Endpoint Protection role server into the Configuration Manager database." }, { @"EPMgr.log", @"Monitors the status of the Endpoint Protection site system role." }, { @"EPSetup.log", @"Provides information about the installation of the Endpoint Protection site system role." }, { @"AdminUI.ExtensionInstaller.log", @"Records information about the download of extensions from Microsoft, and the installation and uninstallation of all extensions." }, { @"FeatureExtensionInstaller.log", @"Records information about the installation and removal of individual extensions when they are enabled or disabled in the Configuration Manager console." }, { @"SmsAdminUI.log", @"Records Configuration Manager console activity." }, { @"dataldr.log", @"Records information about the processing of Management Information Format (MIF) files and hardware inventory in the Configuration Manager database." }, { @"invproc.log", @"Records the forwarding of MIF files from a secondary site to its parent site." }, { @"sinvproc.log", @"Records information about the processing of software inventory data to the site database." }, { @"mtrmgr.log", @"Monitors all software metering processes." }, { @"migmctrl.log", @"Records information about migration actions that involve migration jobs, shared distribution points, and distribution point upgrades." }, { @"DMPRP.log", @"Records communication between management points that are enabled for mobile devices and the management point endpoints." }, { @"dmpmsi.log", @"Records the Windows Installer data for the configuration of a management point that is enabled for mobile devices." }, { @"DMPSetup.log", @"Records the configuration of the management point when it is enabled for mobile devices." }, { @"enrollsrvMSI.log", @"Records the Windows Installer data for the configuration of an enrollment point." }, { @"enrollmentweb.log", @"Records communication between mobile devices and the enrollment proxy point." }, { @"enrollwebMSI.log", @"Records the Windows Installer data for the configuration of an enrollment proxy point." }, { @"enrollmentservice.log", @"Records communication between an enrollment proxy point and an enrollment point." }, { @"SMS_DM.log", @"Records communication between mobile devices, Mac computers and the management point that is enabled for mobile devices and Mac computers." }, { @"easdisc.log", @"Records the activities and the status of the Exchange Server connector." }, { @"DmCertEnroll.log", @"Records details about certificate enrollment data on mobile device legacy clients." }, { @"DMCertResp.htm", @"Records the HTML response from the certificate server when the mobile device legacy client enroller program requests a PKI certificate." }, { @"DmClientHealth.log", @"Records the GUIDs of all the mobile device legacy clients that communicate with the management point that is enabled for mobile devices." }, { @"DmClientRegistration.log", @"Records registration requests and responses to and from mobile device legacy clients." }, { @"DmClientSetup.log", @"Records client setup data for mobile device legacy clients." }, { @"DmClientXfer.log", @"Records client transfer data for mobile device legacy clients and for ActiveSync deployments." }, { @"DmCommonInstaller.log", @"Records client transfer file installation for configuring mobile device legacy client transfer files." }, { @"DmInstaller.log", @"Records whether DMInstaller correctly calls DmClientSetup, and whether DmClientSetup exits with success or failure for mobile device legacy clients." }, { @"DmpDatastore.log", @"Records all the site database connections and queries made by the management point that is enabled for mobile devices." }, { @"DmpDiscovery.log", @"Records all the discovery data from the mobile device legacy clients on the management point that is enabled for mobile devices." }, { @"DmpHardware.log", @"Records hardware inventory data from mobile device legacy clients on the management point that is enabled for mobile devices." }, { @"DmpIsapi.log", @"Records mobile device legacy client communication with a management point that is enabled for mobile devices." }, { @"dmpmsi.log", @"Records the Windows Installer data for the configuration of a management point that is enabled for mobile devices." }, { @"DMPSetup.log", @"Records the configuration of the management point when it is enabled for mobile devices." }, { @"DmpSoftware.log", @"Records software distribution data from mobile device legacy clients on a management point that is enabled for mobile devices." }, { @"DmpStatus.log", @"Records status messages data from mobile device clients on a management point that is enabled for mobile devices." }, { @"DmSvc.log", @"Records client communication from mobile device legacy clients with a management point that is enabled for mobile devices." }, { @"FspIsapi.log", @"Records details about communications to the fallback status point from mobile device legacy clients and client computers." }, { @"CAS.log", @"Records details when distribution points are found for referenced content." }, { @"ccmsetup.log", @"Records ccmsetup tasks for client setup, client upgrade, and client removal. Can be used to troubleshoot client installation problems." }, { @"CreateTSMedia.log", @"Records details for task sequence media creation." }, { @"For System Center 2012 R2 Configuration Manager and later:", @"Records details about the VHD creation and modification process" }, { @"DeployToVhd.log", @"" }, { @"Dism.log", @"Records driver installation actions or update apply actions for offline servicing." }, { @"Distmgr.log", @"Records details about the configuration of enabling a distribution point for PXE." }, { @"DriverCatalog.log", @"Records details about device drivers that have been imported into the driver catalog." }, { @"mcsisapi.log", @"Records information for multicast package transfer and client request responses." }, { @"mcsexec.log", @"Records health check, namespace, session creation and certificate check actions." }, { @"mcsmgr.log", @"Records changes to configuration, security mode and availability." }, { @"mcsprv.log", @"Records multicast provider interaction with Windows Deployment Services (WDS)." }, { @"MCSSetup.log", @"Records details about multicast server role installation." }, { @"MCSMSI.log", @"Records details about multicast server role installation." }, { @"Mcsperf.log", @"Records details about multicast performance counter updates." }, { @"MP_ClientIDManager.log", @"Records management point responses to the client ID requests task sequences initiated from PXE or boot media." }, { @"MP_DriverManager.log", @"Records management point responses to Auto Apply Driver task sequence action requests." }, { @"OfflineServicingMgr.log", @"Records details of offline servicing schedules and update apply actions on operating system .wim files." }, { @"Setupact.log", @"Records details about Windows Sysprep and setup logs." }, { @"Setupapi.log", @"Records details about Windows Sysprep and setup logs." }, { @"Setuperr.log", @"Records details about Windows Sysprep and setup logs." }, { @"smpisapi.log", @"Records details about the client state capture and restore actions, and threshold information." }, { @"Smpmgr.log", @"Records details about the results of state migration point health checks and configuration changes." }, { @"smpmsi.log", @"Records installation and configuration details about the state migration point." }, { @"smpperf.log", @"Records the state migration point performance counter updates." }, { @"smspxe.log", @"Records details about the responses to clients that PXE boot and details about the expansion of boot images and boot files." }, { @"smssmpsetup.log", @"Records installation and configuration details about the state migration point." }, { @"Smsts.log", @"Records task sequence activities." }, { @"TSAgent.log", @"Records the outcome of task sequence dependencies before starting a task sequence." }, { @"TaskSequenceProvider.log", @"Records details about task sequences when they are imported, exported, or edited." }, { @"loadstate.log", @"Records details about the User State Migration Tool (USMT) and restoring user state data." }, { @"scanstate.log", @"Records details about the User State Migration Tool (USMT) and capturing user state data." }, { @"amtopmgr.log", @"Records the activities of the out of band service point, which include the discovery of management controllers, provisioning, audit log control, and power control commands." }, { @"adctrl.log", @"Records details about managing Active Directory accounts that are used by out of band management." }, { @"ADService.log", @"Records details about account creation and security group details in Active Directory." }, { @"amtproxymgr.log", @"Records details about the activities of the site server relating to provisioning and sending instruction files to the out of band service point, which include the following: Discovery of management controllers, AMT provisioning, Audit log control and Power control commands. This log file also records information about out of band management site replication." }, { @"amtspsetup.log", @"Records details about the installation of the out of band service point." }, { @"oobmgmt.log", @"Records details about out of band management activities on AMT-based computers, which includes the AMT provisioning state of the management controller." }, { @"pwrmgmt.log", @"Records details about power management activities on the client computer, which include monitoring and the enforcement of settings by the Power Management Client Agent." }, { @"CMRcViewer.log", @"Records details about the activity of the remote control viewer." }, { @"Oobconsole", @"Records details about running the out of band management console." }, { @"srsrp.log", @"Records information about the activity and status of the reporting services point." }, { @"srsrpMSI.log", @"Records detailed results of the reporting services point installation process from the MSI output." }, { @"srsrpsetup.log", @"Records results of the reporting services point installation process." }, { @"hman.log", @"Records information about site configuration changes, and the publishing of site information to Active Directory Domain Services." }, { @"SMSProv.log", @"Records WMI provider access to the site database." }, { @"ccmcca.log", @"Records details about the processing of compliance evaluation based on Configuration Manager NAP policy processing, and contains the processing of remediation for each software update required for compliance." }, { @"ccmperf.log", @"Records activities related to the maintenance and capture of data related to client performance counters." }, { @"PatchDownloader.log", @"Records details about the process of downloading software updates from the update source to the download destination on the site server." }, { @"PolicyEvaluator.log", @"Records details about the evaluation of policies on client computers, including policies from software updates." }, { @"RebootCoordinator.log", @"Records details about the coordination of system restarts on client computers after software update installations." }, { @"ScanAgent.log", @"Records details about scan requests for software updates, the WSUS location, and related actions." }, { @"SdmAgent.log", @"Records details about tracking of remediation and compliance. However, the software updates log file, Updateshandler.log, provides more informative details about installing the software updates required for compliance. This log file is shared with compliance settings." }, { @"ServiceWindowManager.log", @"Records details about the evaluation of maintenance windows." }, { @"smssha.log", @"The main log file for the Configuration Manager Network Access Protection client and it contains a merged statement of health information from the two Configuration Manager components: location services (LS) and the configuration compliance agent (CCA). This log file also contains information about the interactions between the Configuration Manager System Health Agent and the operating system NAP agent, and also between the Configuration Manager System Health Agent and both the configuration compliance agent and the location services. It provides information about whether the NAP agent successfully initialized, the statement of health data, and the statement of health response." }, { @"Smsshv.log", @"This is the main log file for the System Health Validator point and records the basic operations of the System Health Validator service, such as the initialization progress." }, { @"Smsshvadcacheclient.log", @"Records details about the retrieval of Configuration Manager health state references from Active Directory Domain Services." }, { @"SmsSHVCacheStore.log", @"Records details about the cache store used to hold the Configuration Manager NAP health state references retrieved from Active Directory Domain Services, such as reading from the store and purging entries from the local cache store file. The cache store is not configurable." }, { @"smsSHVQuarValidator.log", @"Records client statement of health information and processing operations. To obtain full information, change the registry key LogLevel from 1 to 0 in the following location: HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SMSSHV\Logging\@GLOBAL" }, { @"smsshvregistrysettings.log", @"Records any dynamic change to the System Health Validator component configuration while the service is running." }, { @"SMSSHVSetup.log", @"Records the success or failure (with failure reason) of installing the System Health Validator point." }, { @"SmsWusHandler.log", @"Records details about the scan process for the Inventory Tool for Microsoft Updates." }, { @"StateMessage.log", @"Records details about software updates state messages that are created and sent to the management point." }, { @"SUPSetup.log", @"Records details about the software update point installation. When the software update point installation completes, Installation was successful is written to this log file." }, { @"UpdatesDeployment.log", @"Records details about deployments on the client, including software update activation, evaluation, and enforcement. Verbose logging shows additional information about the interaction with the client user interface." }, { @"UpdatesHandler.log", @"Records details about software update compliance scanning and about the download and installation of software updates on the client." }, { @"UpdatesStore.log", @"Records details about compliance status for the software updates that were assessed during the compliance scan cycle." }, { @"WCM.log", @"Records details about software update point configurations and connections to the Windows Server Update Services (WSUS) server for subscribed update categories, classifications, and languages." }, { @"WSUSCtrl.log", @"Records details about the configuration, database connectivity, and health of the WSUS server for the site." }, { @"wsyncmgr.log", @"Records details about the software updates synchronization process." }, { @"WUAHandler.log", @"Records details about the Windows Update Agent on the client when it searches for software updates." }, { @"wolcmgr.log", @"Records details about which clients need to be sent wake-up packets, the number of wake-up packets sent, and the number of wake-up packets retried." }, { @"wolmgr.log", @"Records details about wake-up procedures, such as when to wake up deployments that are configured for Wake On LAN." }, { @"CertMgr.log", @"Records certificate and proxy account information." }, { @"CollEval.log", @"Records details about when collections are created, changed, and deleted by the Collection Evaluator." }, { @"Cloudusersync.log", @"Records license enablement for users." }, { @"Dataldr.log", @"Records information about the processing of MIF files." }, { @"ddm.log", @"Records activities of the discovery data manager." }, { @"Distmgr.log", @"Records details about content distribution requests." }, { @"Dmpdownloader.log", @"Records details on downloads from Microsoft Intune." }, { @"Dmpuploader.log", @"Records details for uploading database changes to Microsoft Intune." }, { @"hman.log", @"Records information about message forwarding." }, { @"objreplmgr.log", @"Records the processing of policy and assignment." }, { @"PolicyPV.log", @"Records policy generation of all policies." }, { @"outgoingcontentmanager.log", @"Records content uploaded to Microsoft Intune." }, { @"Sitecomp.log", @"Records details of connector role installation." }, { @"SmsAdminUI.log", @"Records Configuration Manager console activity." }, { @"Smsprov.log", @"Records activities performed by the SMS Provider. Configuration Manager console activities use the SMS Provider." }, { @"SrvBoot.log", @"Records details about the Intune connector installer service." }, { @"Statesys.log ", @"Records the processing of mobile device management messages." }, { @"WindowsUpdate.log", @"Records details about when the Windows Update Agent connects to the WSUS server and retrieves the software updates for compliance assessment and whether there are updates to the agent components." }, { @"Change.log", @"Records details about the WSUS server database information that has changed." }, { @"SoftwareDistribution.log", @"Records details about the software updates that are synchronized from the configured update source to the WSUS server database." }, { @"SCClient_", @"Records the activity in Software Center for the specified user on the client computer." }, { @"SCNotify_", @"Records the activity for notifying users about software for the specified user." }, { @"SleepAgent_", @"Main log file for wake-up proxy." }, { @"CloudDP-", @"Records details for a specific cloud-based distribution point, including information about storage and content access." } };

        // The Help contents

        private const string helpformContent = @"e1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcbm91aWNvbXBhdFxkZWZsYW5nMjA1N3tcZm9udHRibHtcZjBcZnN3aXNzXGZwcnEyXGZjaGFyc2V0MCBTZWdvZSBVSTt9e1xmMVxmc3dpc3NcZnBycTJcZmNoYXJzZXQwIENhbGlicmk7fXtcZjJcZm5pbFxmY2hhcnNldDAgQ2FsaWJyaTt9e1xmM1xmbmlsXGZjaGFyc2V0MiBTeW1ib2w7fX0NCntcY29sb3J0YmwgO1xyZWQwXGdyZWVuMFxibHVlMjU1O1xyZWQ1XGdyZWVuOTlcYmx1ZTE5Mzt9DQp7XCpcZ2VuZXJhdG9yIFJpY2hlZDIwIDEwLjAuMTUwNjN9XHZpZXdraW5kNFx1YzEgDQpccGFyZFx3aWRjdGxwYXJccWNcYlxmMFxmczM2IExvZyBMYXVuY2hlciBWMy42XGZzMzJccGFyDQpcZnMxOFxwYXINClxwYXINClxmczIwIFdvcmtpbmcgd2l0aCBsb2dzIGhhcyBuZXZlciBiZWVuIHRoaXMgZWFzeVxmczE4XHBhcg0KXHBhcg0KDQpccGFyZFx3aWRjdGxwYXJcYjBcZnMxNlxwYXINClxiXGZzMjQgRmVhdHVyZXNccGFyDQpcYjBcZnMxNlxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODBcZnMxOCBHZXQgdG8gQ29uZmlnTWdyLCBPUywgT1MgUm9sZSBsb2dzIGVhc2lseSwgcXVpY2tseVxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIFNjYW4gbXVsdGlwbGUgZGV2aWNlcyBhbmQgbmF2aWdhdGUgYmV0d2VlbiB0aGVtIGluIHRoZSBOYXZpZ2F0aW9uIFBhbmVsLCByYXRoZXIgdGhhbiBvcGVuaW5nIGEgTG9nTGF1bmNoZXIgaW5zdGFuY2UgZm9yIGVhY2ggZGV2aWNlIHlvdSB3YW50IHRvIHNjYW5ccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBWaXN1YWxpc2UgY2hhbmdlcyB0byBsb2dzIG92ZXIgdGltZSB1c2luZyB0aGUgXGkgbW9uaXRvcmluZ1xpMCAgZmVhdHVyZVxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIENob29zZSB5b3VyIG93biBUcmFjaW5nIFRvb2wgc3VjaCBhcyBDTVRyYWNlLCBDTUxvZ1ZpZXdlciwgb3IgYW55IHRvb2wgdGhhdCBjYW4gcmVhZCBmaWxlcyBhbmQgcmVuZGVyIHRoZW0gaW4gcmVhbC10aW1lIHN1Y2ggYXMgTm90ZXBhZCsrXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgT3BlbiBtdWx0aXBsZSBsb2dzIGluIG9uZSB0cmFjZSB0b29sLCBvciBvcGVuIGEgdHJhY2UgdG9vbCBmb3IgZWFjaCBsb2dccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBJbnRlZ3JhdGVzIHdpdGggdGhlIENvbmZpZ01nciBDb25zb2xlLCBsb2NhdGVkIGluIHRoZSBEZXZpY2VzIG5vZGUgYW5kIGNvbnRleHQgbWVudVxccmliYm9uIChVbmluc3RhbGwgdG8gcmVtb3ZlIGludGVncmF0aW9uKVxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIExvZyBoaW50cyBmb3Iga25vd24gU0NDTVxcQ29uZmlnTWdyIGxvZ3MgKGhvdmVyIG92ZXIgYSBsb2cgdG8gc2VlIGEgdG9vbHRpcCBkZXNjcmlwdGlvbiBvZiB0aGUgbG9nLCBub3QgcmVsaWFibGUgd2hlbiBtb25pdG9yaW5nIGlzIHJ1bm5pbmcpXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQWRkIGN1c3RvbSBsb2NhdGlvbnMgZm9yIGxvZyBzY2FubmluZywgdXNpbmcgRml4ZWQgRHJpdmVzIChDOikgb3IgU2hhcmVzIChTSEFSRTopIGFzIGN1c3RvbSBsb2NhdGlvbnMgd2hpY2ggYXJlIHRoZW4gaW5jbHVkZWQgaW4gc2NhbnMgb2YgZGV2aWNlc1xwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIExhdW5jaCBDb25maWd1cmF0aW9uIE1hbmFnZXIgU3VwcG9ydCBDZW50ZXIgZGlyZWN0bHkgZnJvbSBMb2dMYXVuY2hlciAoaWYgaXQgaXMgaW5zdGFsbGVkKVxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIENoYW5nZSBhIENvbmZpZ01nciBTaXRlIG9yIGEgQ2xpZW50cyBMb2cgU2V0dGluZ3MsIHVzaW5nIHRoZSBcaSBMb2cgU2V0dGluZ3NcaTAgIGZlYXR1cmUgKFJlc3RhcnQgdGhlIFNpdGUgb3IgQWdlbnQgc2VydmljZSBmb3IgY2hhbmdlcyB0byB0YWtlIGVmZmVjdClccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBUb2dnbGUgXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTE0NDAgSGlkaW5nIEFyY2hpdmUgbG9ncyAoKi5sb18pXHBhcg0Ke1xwbnRleHRcZjNcJ0I3XHRhYn1IaWRpbmcgQ00gQ3Jhc2hkdW1wIGZvbGRlclxwYXINCntccG50ZXh0XGYzXCdCN1x0YWJ9QXV0b21hdGljIHNvcnRpbmcgb2YgbG9ncyBiYXNlZCBvbiB0aGVpciBsYXN0IG1vZGlmaWVkIGRhdGVccGFyDQp7XHBudGV4dFxmM1wnQjdcdGFifVRyYWNlciBzaG91bGQgb3BlbiBsb2cgZmlsZXMgYXMgbWVyZ2VkXFxtdWx0aXBsZSwgb3IgYXMgc2luZ2xlIGluc3RhbmNlcyBvZiB0aGUgdHJhY2UgdG9vbCBwZXIgbG9nXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQXV0b21hdGljYWxseSBzY2FucyB0aGUgZGV2aWNlIHRoZSB0b29sIGlzIHJ1biBvbiBhdCBsYXVuY2ggdGltZSwgcmVtZW1iZXJzIHdoYXQgZGV2aWNlcyB5b3VccnF1b3RlIHZlIHNjYW5uZWQgZm9yIGVhc3kgYWNjZXNzXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgSW5mbyB0YWIgc2hvd2luZyBkaWFnbm9zdGljIG91dHB1dCBmb3Igd2hlbiB0aGluZ3MgYXJlIGhhcHBlbmluZywgb3Igd2hlbiB0aGV5IGdvIHdyb25nXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQWNjZXB0cyBkZXZpY2UgbmFtZSBlbnRlcmVkIG9uIHRoZSBjb21tYW5kIGxpbmUgKExvZ0xhdW5jaGVyLmV4ZSA8REVWSUNFTkFNRT4pIGZvciBhdXRvbWF0aW9uIHB1cnBvc2VzIChmYWNpbGl0YXRlcyBpbnRlZ3JhdGlvbiBpbnRvIHRoZSBDb25maWdNZ3IgQ29uc29sZSlccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBQcm9ncmVzc2l2ZSBzZWFyY2gsIGZvY3VzIG9uIHRoZSBMb2cgUGFuZWwgYW5kIHN0YXJ0IHR5cGluZyBhIGxvZ3MgbmFtZVxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwIFRoZSBOYXZpZ2F0aW9uIFBhbmVsIGNhbiBiZSB1bnBpbm5lZCB0byBpbmNyZWFzZSB0aGUgTG9nIHZpZXcgc2l6ZSwgdGhlIHNsaWRlIGVmZmVjdCBpcyBkaXNhYmxlZCBpbiBSRFAgc2Vzc2lvbnMgYW5kIGluc3RlYWQgc25hcHMgb3BlbiBhbmQgY2xvc2VkXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgUmlnaHQtY2xpY2sgY29udGV4dCBtZW51IGF2YWlsYWJsZSBmb3IgTG9ncyBhbmQgTmF2aWdhdGlvbiBwYW5lbHNccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBaaXAgZnVsbHkgaW50ZWdyYXRlZCBpbnRvIHRoZSB0b29sLiBaaXAgZnVuY3Rpb25hbGl0eSBhY2Nlc3NpYmxlIGZyb20gdGhlIE5hdmlnYXRpb24gUGFuZWwgZnJvbSB3aGVyZSB5b3UgY2FuIHppcCB1cCBsb2dzIGZyb20gdGhlIHJvb3Qgbm9kZSB0byB0aGUgUHJvZHVjdCBub2Rlcywgb3IgZnJvbSB0aGUgTG9ncyBQYW5lbCB3aGVyZSB5b3UgY2FuIHppcCB1cCBhIGxvZyBvciBhIHNlbGVjdGlvbiBvZiBsb2dzLCBhbmQgZnJvbSBib3RoIHlvdSBjYW4gb3BlbiB0aGUgWmlwIGZvbGRlciwgd2hpY2ggaXMgY29uZmlndXJlZCBieSBkZWZhdWx0IHRvIEM6XFxXSU5ET1dTXFxURU1QLCBhbmQgd2hpY2ggY2FuIGJlIGNoYW5nZWQgb24gdGhlIENvbmZpZ3VyYXRpb24gVGFiLiBUaGUgUmliYm9uIGJ1dHRvbiBmb3IgWklQIGFsbG93cyB5b3UgdG8gcGVyZm9ybSBhbGwgWmlwIG9wZXJhdGlvbnNccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBBdXRvbWF0aWNhbGx5IHJlZnJlc2ggbG9ncyB3aGVuIG1vdmluZyBhcm91bmQgdGhlIG5hdmlnYXRpb24gcGFuZWwgKGNhbiBiZSB0b2dnbGVkIG9uXFxvZmYpXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQ2hhbmdlIGZvbnQgYW5kIGZvbnQgc2l6ZSBpbiB0aGUgQ29uZmlndXJhdGlvbiB0YWJccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBSZXNjYW4gYSBkZXZpY2UsIHVzZWZ1bCBmb3Igd2hlbiBjdXN0b20gbG9jYXRpb25zIGhhdmUgYmVlbiBhZGRlZCBhbmQgYSBkZXZpY2UgcmVzY2FuIGlzIHJlcXVpcmUgdG8gZGV0ZWN0IHRoZSBuZXcgcnVsZXNccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBZb3UgY2FuIG5vdyBtb25pdG9yIHRoZSBQcm9kdWN0IGFuZCBDYXRlZ29yeSAoQ29uZmlnTWdyLCBJSVMsIFNRTCksIHdoZXJlYXMgYmVmb3JlIHlvdSBjb3VsZCBvbmx5IG1vbml0b3IgYSBDYXRlZ29yeSAoU2l0ZSlccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MCBQcmVzcyBGNSB3aGVuIGluIHRoZSBOYXZpZ2F0aW9uIG9yIExvZyBwYW5lbCB0byByZWZyZXNoIGp1c3QgbGlrZSBGaWxlIEV4cGxvcmVyXHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQnVnIGZpeGVkIHdoaWNoIGNhdXNlZCBTUUwgRGF0YWJhc2UgU2VydmVyIGFuZCBJSVMgdG8gYmUgaWdub3JlZCBkdXJpbmcgYSBzY2FuXHBhcg0KDQpccGFyZFxmczE2XHBhcg0KDQpccGFyZHtcKlxwblxwbmx2bGNvbnRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxwYXINClxiXGZzMjQgUmVxdWlyZW1lbnRzXHBhcg0KXGIwXGZzMTZccGFyDQoNClxwYXJkXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTA4MFxmczE4IEFkbWluaXN0cmF0aXZlIFNoYXJlc1xmczE2XHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODBcZnMxOCBSZW1vdGUgUmVnaXN0cnlcZnMxNlxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJke1xwbnRleHRcZjNcJ0I3XHRhYn17XCpccG5ccG5sdmxibHRccG5mM1xwbmluZGVudDB7XHBudHh0YlwnQjd9fVxmaS0zNjBcbGkxMDgwXGZzMTggTmV0IDQuMCBvciBhYm92ZVxmczE2XHBhcg0KDQpccGFyZFxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTEwODAgQXdlc29tZSBsb2cgcmVhZGluZyBza2lsbHMgYXJlIG5vdCBpbmNsdWRlZCA6LShccGFyDQoNClxwYXJkXHBhcg0KXHBhcg0KXGJcZnMyNCBXaGF0IGlzIExvZ0xhdW5jaGVyP1xiMFxmczE2XHBhcg0KXHBhcg0KDQpccGFyZFxsaTcyMFxwYXINCkkgd3JvdGUgTG9nTGF1bmNoZXIgdG8gdGFrZSB0aGUgaGFzc2xlIG91dCBvZiB3b3JraW5nIGFyb3VuZCBDb25maWdNZ3IgbG9ncywgZm9yIHNvbWUsIGxvZ3MgaXMgYSBoYXJkbHkgdmlzaXRlZCBhcmVhIG9mIHRoZSBwcm9kdWN0LCBidXQgZm9yIG90aGVycyBsaWtlIG1lIHdlJ3JlIHRoZXJlIG1vc3Qgb2YgdGhlIHRpbWUsIHNpbmNlIHdlIG1vdmUgZnJvbSBvbmUgY3VzdG9tZXIgdG8gdGhlIG5leHQgdHJvdWJsZXNob290aW5nIG9yIHN0YW5kaW5nIHRoaW5ncyB1cC5ccGFyDQpccGFyDQpJJ3ZlIGxpdGVyYWxseSB0aHJvd24gYWxsIHRoYXQgaGFzc2xlIG91dCB0aGUgd2luZG93LCBpZiB5b3UgaWdub3JlIHRoZSBmYWN0IHRoYXQgeW91IG5lZWQgdG8gaW5zdGFsbCBMb2dMYXVuY2hlciB0byBvcGVuIHRoZSB3aW5kb3cgaW4gdGhlIGZpcnN0IHBsYWNlLlxwYXINClxwYXINCkxvZ0xhdW5jaGVyIGlzIGEgcHJvZHVjdGl2aXR5IHRvb2wsIGl0IHJlZHVjZXMgdGhlIGFtb3VudCBvZiBlZmZvcnQgaXQgdGFrZXMgdG8gd29yayB3aXRoIGxvZ3MsIGl0IGlzIGNsZXZlciBhdCBkZXRlY3RpbmcgYSB2YXJpZXR5IG9mIHByb2R1Y3QgbG9ncyB3aGVyZXZlciB0aGV5IG1heSBiZSBpbnN0YWxsZWQsIGFuZCBpdCBsZXRzIHlvdSBtb25pdG9yIHRoZW0gZm9yIGNoYW5nZXMsIGFuZCBpcyBhIGxpdGVyYWwgbGF1bmNoIHBhZCB0byBnZXQgdG8gd2hhdGV2ZXIgbG9ncyBuZWVkIHRvIGJlIGNoZWNrZWQgb3V0IHVzaW5nIHdoYXRldmVyIFRyYWNlIHRvb2wgeW91IHdhbnQgdG8gdXNlLCBDTVRyYWNlIGJlaW5nIHRoZSBwcmVkb21pbmF0ZSB0b29sLlxwYXINCg0KXHBhcmRccGFyDQoNClxwYXJkXHdpZGN0bHBhclxwYXINClxwYXINClxiXGZzMjQgQ2hvb3NpbmcgYSBUcmFjZXJcYjBccGFyDQpcZnMxNlxwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpNzIwXGZzMThccGFyDQpPbiBzdGFydHVwIHlvdSB3b3VsZCBoYXZlIGJlZW4gcHJvbXB0ZWQgdG8gbG9jYXRlIGEgdHJhY2luZyB0b29sLCBpbnN0ZWFkIG9mIHBlcmZvcm1pbmcgZGV0ZWN0aW9uIElccnF1b3RlIHZlIGxlZnQgaXQgZm9yIHlvdSB0byBkZWNpZGUgd2hhdCBpcyB5b3VyIHRyYWNpbmcgdG9vbCwgYW5kIHdoZXJlIHRvIGZpbmQgaXQuXHBhcg0KXHBhcg0KXHBhcg0KWW91IGNhbiBjaGFuZ2UgdGhpcyBwYXRoIGFuZCB0aGUgdG9vbCBiZWluZyB1c2VkIGJ5IExvZ0xhdW5jaGVyIGJ5IHZpc2l0aW5nIHRoZSBcaSBDb25maWd1cmF0aW9uXGkwICB0YWIuXHBhcg0KXHBhcg0KXHBhcg0KTG9nTGF1bmNoZXIgd2lsbCBzdG9yZSB0aGUgZmlyc3QgdHJhY2VyIGNob3NlbiBpbiBIS0xNXFxTb2Z0d2FyZVxcU01TTWFyc2hhbGxcXExvZ0xhdW5jaGVyLCB3aGljaCB3aWxsIHRoZW4gYmUgdXNlZCBieSBkZWZhdWx0IGZvciBhbGwgbmV3IHVzZXJzLCB1bmxlc3MgdGhleSBvcHQgdG8gbG9jYXRlIGEgdHJhY2luZyB0b29sIHRoZW1zZWx2ZXMuIFxwYXINClxwYXINClxwYXINClRoZSBVc2VycyBjaG9pY2Ugb2YgdHJhY2VyIGlzIHN0b3JlZCBpbiBIS0NVXFxTb2Z0d2FyZVxcU01TTWFyc2hhbGxcXExvZ0xhdW5jaGVyLlxwYXINClxwYXINClxwYXINCkNNVHJhY2UgY2FuIGJlIGZvdW5kIGluIHlvdXIgQ29uZmlnTWdyIERpc3RyaWJ1dGlvbiBraXQsIGFuZCBDb25maWd1cmF0aW9uIE1hbmFnZXIgU3VwcG9ydCBDZW50ZXIgd2l0aCBDTUxvZ1ZpZXdlciBjYW4gYmUgZm91bmQgaGVyZToge3tcZmllbGR7XCpcZmxkaW5zdHtIWVBFUkxJTksgaHR0cHM6Ly93d3cubWljcm9zb2Z0LmNvbS9lbi11cy9kb3dubG9hZC9kZXRhaWxzLmFzcHg/aWQ9NDI2NDUgfX17XGZsZHJzbHR7aHR0cHM6Ly93d3cubWljcm9zb2Z0LmNvbS9lbi11cy9kb3dubG9hZC9kZXRhaWxzLmFzcHg/aWQ9NDI2NDVcdWwwXGNmMH19fX1cZjBcZnMxOFxwYXINClxwYXINClxwYXINCg0KXHBhcmRcd2lkY3RscGFyXHNhMTYwXHNsMjUyXHNsbXVsdDFcYlxmczI0IFNjYW5uaW5nIGZvciBMb2dzXGZzMTZccGFyDQoNClxwYXJkXHdpZGN0bHBhclxsaTcyMFxzYTE2MFxzbDI1MlxzbG11bHQxXGIwXGZzMThccGFyDQpUbyBzY2FuIGEgcmVtb3RlIGRldmljZSwgZ28gdG8gdGhlIEhvbWUgdGFiIGFuZCBlbnRlciB0aGUgZGV2aWNlcyBuYW1lIGludG8gdGhlIERldmljZSBmaWVsZCwgY2xpY2sgXGkgU2NhblxpMCAuXHBhcg0KXHBhcg0KT24gc3RhcnR1cCBMb2dMYXVuY2hlciB3aWxsIHNjYW4gdGhlIGRldmljZSBpdCBpcyBydW4gb24uXHBhcg0KXHBhcg0KQSBzY2FuIHdpbGwgcmV0cmlldmUgYWxsIHRoZSBtZXRhLWRhdGEgbmVlZGVkIHRvIHJlbmRlciB0aGUgbG9nIHZpZXcsIHN1Y2ggYXMgcGF0aCwgZmlsZW5hbWUsIHNpemUsIGxhc3QgbW9kaWZpZWQuIER1cmluZyB0aGUgdXNlIG9mIHRoZSB0b29sIHRoaXMgaW5mb3JtYXRpb24gaXMgbm90IHVwZGF0ZWQgdW5sZXNzIHlvdSBjbGljayBvbiBSZWZyZXNoIG9yIHN0YXJ0IHRoZSBNb25pdG9yaW5nIGZlYXR1cmUuXHBhcg0KXHBhcg0KDQpccGFyZFx3aWRjdGxwYXJcc2ExNjBcc2wyNTJcc2xtdWx0MVxiXGZzMjQgT3BlbmluZyBMb2dzXHBhcg0KDQpccGFyZFx3aWRjdGxwYXJcbGk3MjBcc2ExNjBcc2wyNTJcc2xtdWx0MVxiMFxmczE4XHBhcg0KVG8gb3BlbiBsb2dzIHVzZSB0aGUgT3BlbiBidXR0b24gb24gdGhlIEhvbWUgdGFiLCBvciBoaWdobGlnaHQgdGhlIGxvZ3MgYW5kIHByZXNzIEVudGVyLCBvciByaWdodCBjbGljayBhIGxvZyBvciBvbmUgb2YgdGhlIHNlbGVjdGVkIGxvZ3MgYW5kIHVzZSB0aGUgY29udGV4dCBtZW51OyBZb3UgY2FuIGFsc28gZ2V0IHRvIHRoZSBsb2dzIGZvbGRlciB1c2luZyB0aGUgY29udGV4dCBtZW51LlxwYXINClxwYXINCg0KXHBhcmRcd2lkY3RscGFyXHNhMTYwXHNsMjUyXHNsbXVsdDFcYlxmczI0IE1vbml0b3JpbmcgTG9nc1xwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpNzIwXHNhMTYwXHNsMjUyXHNsbXVsdDFcYjBcZnMxOFxwYXINCkxvZ0xhdW5jaGVyIGNhbiBtb25pdG9yIGxvZ3MgYnkgdXBkYXRpbmcgdGhlIG1ldGEtZGF0YSByZXRyaWV2ZWQgZHVyaW5nIGEgU2Nhbiwgb24gYSByZXBlYXRpbmcgZnJlcXVlbmN5LCB3aGljaCBpcyBieSBkZWZhdWx0IDUgc2Vjb25kcy5ccGFyDQpccGFyDQpNb25pdG9yaW5nIG1lYW5zIGtlZXBpbmcgYW4gZXllIG9uIHRoZSBsYXN0IHRpbWUgdGhlIGxvZ3Mgd2VyZSBtb2RpZmllZC5ccGFyDQpccGFyDQpUbyB2aXN1YWxpc2UgdGhpcywgdGhlIHRvb2wgd2lsbCB1c2Ugd2hhdGV2ZXIgaXMgZGVmaW5lZCBmb3IgXGkgTmV3ZXN0XGkwICBjb2xvdXIsIGFuZCBjaGFuZ2UgdGhlIG1vZGlmaWVkIGxvZ3MgZW50cnkgdG8gdGhhdCBjb2xvdXIsIHRoZXJlYWZ0ZXIgdGhlIGNvbG91ciB3aWxsIGJlIGNoYW5nZWQgYXQgZWFjaCBzY2FuIGludGVydmFsIGFsb25nIGEgZ3JhZGllbnQgdG93YXJkcyB3aGF0ZXZlciBpcyBkZWZpbmVkIGZvciBPbGRlc3QgY29sb3VyLCB1bmxlc3MgdGhlIGxvZyBpcyBtb2RpZmllZCBhZ2Fpbiwgd2hpY2ggd2lsbCByZXR1cm4gaXQgdG8gdGhlIFxpIE5ld2VzdFxpMCAgY29sb3VyLlxwYXINClxwYXINClRoaXMgY29sb3VyIHZpc3VhbGlzYXRpb24gcmVhbGx5IGhlbHBzIGNvbnRyYXN0IGFjdGl2aXR5IGluIHRoZSBTQ0NNXFxDb25maWdNZ3IgcHJvZHVjdHMgbG9ncywgc2hvd2luZyB3aGF0IGhhcyBhbmQgaGFzblxycXVvdGUgdCBiZWVuIHRvdWNoZWQgc2luY2UgdGhlIG1vbml0b3Jpbmcgc2Vzc2lvbiBiZWdhbi5ccGFyDQpccGFyDQpUbyBiZWdpbiBtb25pdG9yaW5nOlxwYXINClxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTE0NDBcc2ExNjBcc2wyNTJcc2xtdWx0MSBGaXJzdCBzY2FuIGEgZGV2aWNlIGZyb20gdGhlIEhvbWUgdGFiXGxpbmVcbGluZSBUaGlzIHdpbGwgcG91ciB0aGUgbWV0YWRhdGEgZm9yIHRoZSBsb2dzIGZvdW5kIGludG8gdGhlIExvZyBEYXRhIHN0b3JlIFxwYXINCntccG50ZXh0XGYzXCdCN1x0YWJ9U2VsZWN0IHRoZSBNb25pdG9yaW5nIHRhYlxwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpMTQ0MFxzYTE2MFxzbDI1MlxzbG11bHQxIFlvdVxycXVvdGUgbGwgbm90ZSB0aGF0IHRoZSBkZWZhdWx0IHJlZnJlc2ggaW50ZXJ2YWwgaXMgc2V0IHRvIDUgc2Vjb25kcywgYW5kIElccnF1b3RlIGQgcmVjb21tZW5kIG5vdCBnb2luZyBiZWxvdyB0aGF0IHVubGVzcyBpdCBpcyBmb3IgdmVyeSBzaG9ydCBtb25pdG9yaW5nIHNlc3Npb25zXHBhcg0KDQpccGFyZHtccG50ZXh0XGYzXCdCN1x0YWJ9e1wqXHBuXHBubHZsYmx0XHBuZjNccG5pbmRlbnQwe1xwbnR4dGJcJ0I3fX1cZmktMzYwXGxpMTQ0MFxzYTE2MFxzbDI1MlxzbG11bHQxIENob29zZSB0aGUgY29sb3VycyBmb3IgdGhlIGNvbG91ciBncmFkaWVudFxsaW5lXGxpbmUgVGhpcyBmb3JtcyB0aGUgUGFsZXR0ZSB1c2VkIHRvIHNob3cgd2hhdCBsb2dzIGhhdmUgYmVlbiB0b3VjaGVkIHJlY2VudGx5IGFuZCB3aGljaCBvbmVzIGhhdmVuJ3RccGFyDQp7XHBudGV4dFxmM1wnQjdcdGFifVNlbGVjdCBhIG5vZGUgaW4gdGhlIE5hdmlnYXRpb24gUGFuZWwsIGVpdGhlciB0aGUgZGV2aWNlIE5vZGUsIGEgUHJvZHVjdCBub2RlIHN1Y2ggYXMgXGkgQ29uZmlnTWdyXGkwICwgb3IgYSBQcm9kdWN0IENhdGVnb3J5IG5vZGUgc3VjaCBhcyBcaSBBZ2VudFxcTVBcaTBccGFyDQp7XHBudGV4dFxmM1wnQjdcdGFifVNlbGVjdCB0aGUgXGkgTW9uaXRvcmluZ1xpMCAgYnV0dG9uIHRvIHN0YXJ0IG1vbml0b3JpbmcsIG5vdGUgdGhlIGljb24gY2hhbmdlc1xwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpMTQ0MFxzYTE2MFxzbDI1MlxzbG11bHQxIFlvdVxycXVvdGUgbGwgc2VlIHRoYXQgdGhlIHByb2R1Y3Qgb3IgY2F0ZWdvcnkgaW4gdGhlIE5hdmlnYXRpb24gUGFuZWwgYmVpbmcgbW9uaXRvcmVkLCB3aWxsIG5vdyBiZSBoaWdobGlnaHRlZCBpbiByZWQsIGFuZCBhIHByb2dyZXNzIGJhciB3aWxsIGJlIHNob3duIHVudGlsIG1vbml0b3Jpbmcgc3RvcHMsIHRoaXMgaXMgc28gdGhhdCB5b3UgY2FuIGVhc2lseSBzZWUgdGhhdCBtb25pdG9yaW5nIGlzIHRha2luZyBwbGFjZSwgYW5kIHdoYXQgaXMgYmVpbmcgbW9uaXRvcmVkLlxwYXINCg0KXHBhcmR7XHBudGV4dFxmM1wnQjdcdGFifXtcKlxwblxwbmx2bGJsdFxwbmYzXHBuaW5kZW50MHtccG50eHRiXCdCN319XGZpLTM2MFxsaTE0NDBcc2ExNjBcc2wyNTJcc2xtdWx0MSBVbnBpbiB0aGUgTmF2aWdhdGlvbiBQYW5lbCB0byBtYWtlIHRoZSBsb2cgdmlldyBsYXJnZXIsIG5vdCBuZWNlc3NhcnkgYnV0IGlmIHRoZSBsb2cgZmlsZXMgaGF2ZSBsb25nIG5hbWVzIGl0IGNhbiBoZWxwXHBhcg0Ke1xwbnRleHRcZjNcJ0I3XHRhYn1TZWxlY3QgdGhlIFxpIE1vbml0b3JpbmdcaTAgIGJ1dHRvbiBhZ2FpbiB0byBzdG9wIG1vbml0b3JpbmdccGFyDQoNClxwYXJkXHdpZGN0bHBhclxiXGZzMjRccGFyDQpDb25zb2xlIEludGVncmF0aW9uXHBhcg0KXHBhcg0KXGIwXGZzMTZccGFyDQoNClxwYXJkXHdpZGN0bHBhclxsaTcyMFxmczE4IExvZ0xhdW5jaGVyIHdpbGwgaW50ZWdyYXRlIGludG8gdGhlIENvbmZpZ01nciBDb25zb2xlIGR1cmluZyBNU0kgaW5zdGFsbGF0aW9uIGlmIGl0IGlzIGRldGVjdGVkIGxvY2FsbHksIHlvdSBtYXkgaGF2ZSBub3RpY2VkIHRoZSBDTUQgcHJvbXB0IGJveCBvcGVuIGFuZCBjbG9zZSwgdGhhdCBpcyB0aGUgQ29uc29sZSBpbnRlZ3JhdGlvbiB0b29sIHJ1bm5pbmcsIGFsc28gYXZhaWxhYmxlIG9uIEdpdEh1Yi4gWW91J2xsIHNlZSB0aGUgaW50ZWdyYXRpb24gYXBwZWFyIG9uIHRoZSBDb25maWdNZ3IgQ29uc29sZXMgRGV2aWNlcyBSaWJib24gaW4gQXNzZXRzIGFuZCBDb21wbGlhbmNlLCBhbmQgaW4gdGhlIGNvbnRleHQgbWVudSBmb3IgYW4gaW5kaXZpZHVhbCBkZXZpY2UuXHBhcg0KXHBhcg0KXHBhcg0KVW5pbnN0YWxsIExvZ0xhdW5jaGVyIHRvIHJlbW92ZSB0aGUgaW50ZWdyYXRpb24sIG9yIHRvIHJlbW92ZSBDb25zb2xlIGludGVncmF0aW9uIG1hbnVhbGx5LCBvcGVuIEZpbGUgRXhwbG9yZXIsIHZpc2l0IHlvdXIgQ29uc29sZSBpbnN0YWxsYXRpb24gcGF0aCwgc2VhcmNoIGZvciBcaSBMb2dMYXVuY2hlci5YTUxcaTAgIGFuZCBkZWxldGUgdGhlIHR3byBmaWxlcyB0aGF0IGFwcGVhciwgcmVzdGFydCB0aGUgQ29uc29sZSB0byBjb21wbGV0ZSBkaXNpbnRlZ3JhdGlvbi5ccGFyDQpcZnMxNlxwYXINCg0KXHBhcmRcd2lkY3RscGFyXHBhcg0KXGJcZnMyNCBBY2tub3dsZWRnZW1lbnRzXHBhcg0KXHBhcg0KXGIwXGZzMThccGFyDQoNClxwYXJkXHdpZGN0bHBhclxsaTcyMCBUaGFuayB5b3UgdG8gdGhlIHRvb2wgdGVzdGVycyB3aG8gZ2F2ZSB1cCBzb21lIHRpbWUsIHBvaW50ZWQgb3V0IGJ1Z3MgYW5kIG9mZmVyZWQgdXAgaWRlYXMsIFplbmcgWWluZ2h1YSAoU2FuZHkpLCBNYXJrIEFsZHJpZGdlLCBTaW1vbiBEZXR0bGluZywgUGF1bCBXaW5zdGFubGV5IGFuZCBOaWFsbCBCcmFkeS4gT3RoZXJzIHdobyBoYXZlIGdpdmVuIG1lIHRpcHMgYW5kIGZlZWRiYWNrIG9uIFNvY2lhbCBwbGF0Zm9ybXMsIHRoYW5rcyFccGFyDQpccGFyDQoNClxwYXJkXHdpZGN0bHBhclxwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpNzIwIFZlcnNpb24gMy54IG9ud2FyZHMgaW1wbGVtZW50cyBhIHZlcnkgaGFuZHkgXGkgUmliYm9uXGkwICBleHRlbnNpb24gdG8gVmlzdWFsIFN0dWRpbywgb3JpZ2luYWxseSB3cml0dGVuIGJ5IEpvc2UgTWVuZWRleiBQb28gYW5kIG5vdyBtYWludGFpbmVkIGJ5IGEgY29tbXVuaXR5IG9mIGF3ZXNvbWUgY29kZXJzLCB0aGUgRExMIGhhcyBiZWVuIG1lcmdlZCB3aXRoIHRoaXMgUG9ydGFibGUgRXhlY3V0YWJsZSBmaWxlIChMb2dMYXVuY2hlci5leGUpIHRvIHByb3ZpZGUgdGhlIHJpYmJvbiBmdW5jdGlvbmFsaXR5LlxwYXINClxwYXINClxwYXINCklccnF1b3RlIGQgbGlrZSB0byB0aGFuayBKb3NlIE1lbmVkZXogUG9vIGFuZCBlc3BlY2lhbGx5IHRoZSB0ZWFtIHdobyBjdXJyZW50bHkgbWFpbnRhaW4gdGhlIFJpYmJvbiwgYW5kIHRha2UgbXkgaGF0IG9mZiB0byB0aGVtIGZvciBkb2luZyBzdWNoIGEgZ29vZCBqb2IgYXQgZXhwb3NpbmcgaXRzIGZ1bmN0aW9uYWxpdHkgc28gdGhhdCBJIGNvdWxkIGdldCBpdCwgd2l0aCBhIGxpdHRsZSBsaWdodCB3b3JrLCBpbnRvIHRoaXMgdG9vbC5ccGFyDQpccGFyDQoNClxwYXJkXHdpZGN0bHBhclxwYXINCg0KXHBhcmRcd2lkY3RscGFyXGxpNzIwIFRoZSBETEwgZm9yIHRoZSBSaWJib24gYW5kIGEgdGVtcGxhdGUgcHJvamVjdCBpcyBhdmFpbGFibGUgaGVyZToge3tcZmllbGR7XCpcZmxkaW5zdHtIWVBFUkxJTksgaHR0cHM6Ly93d3cuY29kZXByb2plY3QuY29tL0FydGljbGVzLzM2NDI3Mi9FYXNpbHktQWRkLWEtUmliYm9uLWludG8tYS1XaW5Gb3Jtcy1BcHBsaWNhdGlvbi1DcyB9fXtcZmxkcnNsdHtodHRwczovL3d3dy5jb2RlcHJvamVjdC5jb20vQXJ0aWNsZXMvMzY0MjcyL0Vhc2lseS1BZGQtYS1SaWJib24taW50by1hLVdpbkZvcm1zLUFwcGxpY2F0aW9uLUNzXHVsMFxjZjB9fX19XGYwXGZzMThccGFyDQpccGFyDQpccGFyDQpBbmQgVmVyc2lvbiAzLjUgaW50cm9kdWNlZCBaaXAgZnVuY3Rpb25hbGl0eSB1c2luZyB0aGUgdmVyeSBuZWF0IERvdE5ldFpJUCBzb2x1dGlvbiwgdGhlIERETCBmb3Igd2hpY2ggaGFzIGFsc28gYmVlbiBtZXJnZWQgaW50byB0aGlzIFBvcnRhYmxlIEV4ZWN1dGFibGUgZmlsZSAoTG9nTGF1bmNoZXIuZXhlKS5ccGFyDQpccGFyDQpccGFyDQpUaGUgRExMIGZvciBEb3ROZXRaSVAgaXMgYXZhaWxhYmxlIGhlcmU6IHt7XGZpZWxke1wqXGZsZGluc3R7SFlQRVJMSU5LIGh0dHBzOi8vZG90bmV0emlwLmNvZGVwbGV4LmNvbS8gfX17XGZsZHJzbHR7aHR0cHM6Ly9kb3RuZXR6aXAuY29kZXBsZXguY29tL1x1bDBcY2YwfX19fVxmMFxmczE4XHBhcg0KDQpccGFyZFx3aWRjdGxwYXJcZnMxNiAgXHBhcg0KXGJcZnMyNFxwYXINCkF1dGhvclxwYXINClxiMFxmczE2XHBhcg0KDQpccGFyZFx3aWRjdGxwYXJcbGk3MjAgIFxwYXINClxmczE4IFdyaXR0ZW4gYnkgUm9iZXJ0IE1hcnNoYWxsLCBFbnRlcnByaXNlIE1vYmlsaXR5IE1WUCwgdXNpbmcgQyMgYW5kIFZpc3VhbCBTdHVkaW8gMjAxNS5ccGFyDQpccGFyDQpccGFyDQpUaGUgc291cmNlIGZvciB0aGlzIHByb2plY3QgY2FuIGJlIGZvdW5kIG9uIEdpdEh1YiBoZXJlOiB7e1xmaWVsZHtcKlxmbGRpbnN0e0hZUEVSTElOSyBodHRwczovL2dpdGh1Yi5jb20vUm9iVUsxMDEvTG9nTGF1bmNoZXIgfX17XGZsZHJzbHR7aHR0cHM6Ly9naXRodWIuY29tL1JvYlVLMTAxL0xvZ0xhdW5jaGVyXHVsMFxjZjB9fX19XGYwXGZzMThccGFyDQpccGFyDQpccGFyDQp7XGYxXGZzMjR7XGZpZWxke1wqXGZsZGluc3R7SFlQRVJMSU5LICJodHRwOi8vd3d3LnNtc21hcnNoYWxsLmNvbSIgfX17XGZsZHJzbHR7XHVsXGNmMVxjZjJcdWxcZjBcZnMxOCBTTVNNYXJzaGFsbCBMdGR9fX19XGYwXGZzMTggIFxlbmRhc2ggIExhc3QgcmV2aXNpb24gZGF0ZSA6IE1heSAyMDE3XGZzMTZccGFyDQoNClxwYXJkXHNhMjAwXHNsMjc2XHNsbXVsdDFcZjJcZnMyMlxsYW5nOVxwYXINCn0NCgA=";

        // Images used to populate the Ribbon Icons

        public const string imagetextScan = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QITDyMWaIFMmwAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAABoElEQVRIx93Vu2sVURAG8J/XhEAQlXSBJKSIDzQhbf4BCwubBAnYWNgoqIUvsJBELQIWVgqCpDGPLhaCBPIXKFHwraBop0mRiKaIoHhtZmVZ9j6yd7FwYGB3Z/Z8Z7458x3+F9uGLkyhG9WS1v2JaSxCG5YwgRcBWoZ14CG+4Bm8K4GNPDuDi1ApgaJqI/BKJnAV61hr4N8x1uwu2jLvE+FbsV04jwP4hee4gU3szKvkGlZq+CouZ/KP4nNUdx03g74NPMF8kvi2YC8O4VON2A58w748kEt4VcNf42wqdyOoqmVDWG6lkv3JoDWwtbzGn8N4nZ/u4Tb24GMTII/RV7SSITxoIm8leXhTsPGb6KwT3xtS9Xdi+wqAHKnDQju+YjgNUsSP4UQc1eOh4r04FYowmpaVHwXpmsMA+nEQsyHvPbiFBRxOkq+0UE3id3EhtK8/9X01rZSDcfZ/19l5J2ZwP6rISnwlvi3jZAw2nN4KPcm1MNlk/vvoz5284NMWaBvJXOtVLGYnfjc+4GXBwzCAR7H4eonXeUOKbf8XSH8AhfuPZZ11xOgAAAAASUVORK5CYII=";
        public const string imagetextMonitor = "iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QETDwg3FTjbfAAAA3hJREFUaN7tmktsTkEUx39fW1pNS7U01CORtEKjRdMEISEWQoTYsWgiFmLBxoaErQWxkZAoERKPhY3HgiAWEiJCJJ5Rj9CoVDyr1QfVftfmf5PjGm2/uv36jTjJzcw9M3fm/Oc8ZubkJoIgWMh/yhxKROqLgGwg8ED2bKABaI4C2Q/UAT2eAEkAX4EqoCPHNFQBRZ5Z1DhgTBRISMuAN4MYNIhoeCgpHzgKVIcMF5AGoGkQg48EutMEJA/otIwsR6ecQQy8DzgBFKYJSE5U+zkxDbwFaAdGywHTTlkxjFGrUDgKGDFcXh8HkHnGR7J9BlIT83jDAmQUUG7eS30FUghMi4RFL4EUAVPM+zRfgdSqfG805CWQFSqPmbOPl0CWq7zgM5AiCX4PeC1esQ9AaoCJDm3cAVpUL3F8V6BNMy8TgKwHbgJ7HUDuAm19aGQrcAtYlS7tXNOdIhpCFwOtakuaY8gT4Buw1NxHmh23uKdquxGjrAVanAAoG4hGSoBzOtWGgq0DxgNjpYlXavuiCSzNVF+AhcCsvxB+NJCbimlNACYBU4FHcur7wBJjKmXaM1qBRvHbHftItQB36f3AH+TI1ZiTHE8ZsE1zfdTiBAMxrV6TgAh0YyyVdprE26nyjPn+gWOCg+LtAV6qXu2Ye7PMtMfx9BpZAuCUzPsX0+oLSBJ4Acw16Zfz6vNB5Ubz/XXxxhheCLwEqFe93gHkrdoGDcR1Q1ykfSEBfJfQaMArwGqz8V0y33UZ02wFKoDJMs9PwGFgE7AG6ND9Pqn+E4CrwFqdqKNJjTpptR3Y1V8o/1PUslSmyQMjeEjHxQ/vJ7v1vt30uR1ZXfvMT8HZCwaikb6oWY4/R9qx9F1luGluUHk24gsnpRFLjcDjfuZu6y8bkSrtAC4CpyP8z2blyhUgninSYE4BlY6gkIwjrZIqXQYWSDOuFSsGVppI1hLp1ztU+aFUKSn7jFK7Ma2KiN+lJdEVF4UrP13mg8OPMjqLEnX2mcAM7SHP0wUkTo10yv4rtUBHfMtrWY30mjEP+QqkA/ih+lPgna9Aus1+cNm35EPUR8LD5jWfgXRovE4dFNNKcUatRh2xW9IZdocCSHgo9DJBlzHkAtLjgdy//QvgMq0ZjmxIplG+nj6BXPHRtCyQh8Bs/PuFozV8sQ3e/lTzz1DiX/nx7CeehejkjcLTngAAAABJRU5ErkJggg==";
        public const string imagetextmonitorStop = "iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QETDxckXNyUPAAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAADuklEQVRo3t2az0sbURDHP/M2gaCmB39cCoGC0F4axENBsQfBQ8FbQQr2L+lR/4CePPVcKHixJw+FCgF7ED1GBAWxUKpoFaFSKanm9bCz7eZlo7sxaXczsGTZvDfvO2/mzZs384QOkEAB6ANKwIyFR0AZqANGmwXvVYFdC2sCX4BLCz87gCEZGUWkncsWngLT4gswlJDdGbAGVAQ+Wai6Y3SVPJgSeAt8BWyHnq8Cbz2Y6hpw81eAgsASUOugAO5TE1jyfHP9M/adTEuUc557csX3CeCdhQctmn8DTnUNbAH7guwJ9geARfot9iEwauGJrqFhYKTF2J+BlznY+AU2wNI25SAPLLaaQYFNYEFg0kAxgZaLApPad/MGDS0aH0PbXkD0930LAQ4F5pKAv0WoOYHDFmOthDEltjWB1RaM3/hLpg23d/OYnvKOGnM1savNQT6kiXqI4ZHAfLe9oo5xFBq3HmgmlpkZXdhRa0JgR2Ccf0QC4wI7UWsmD2JiMJhsIcSA64676eoVy0CUMIrxxo2uIHDgdDz6l5qI0oxjZlbgINhnImdBNztX+nn+MykGF9dSpHVoaFCL8E5dN6eYZuZ6s1pkOKOxU8M+EbjYlJDn7jOKuUGIshsACsyRMlJMbqBZ1i0DNBS/H+qwJfCBmPGNwDQwAVwnD6TZsFCJs2kqpi2N1QDuK/ZqcChadiRdSDBL08A5cNXmc6484tKCg3VZoIDAoPhRa/DHya1+ulGQVwqo3bD9Cp9H3PEmgZNQ/1OBQQOUnJPdqcB2ghm67oDtXydou63HhYCGLJQMMOO0rdbhgpSSYqs6ws0YTRSEP26RcnIxWnhk9KQWpn3STy7GclPCQpC99GukCWPduNFHcMZOtyBNGI2hR6jJtCzSn3bQERibTUtTNikXpAmjZ1yfDIxmwJJcjOtGYNfxyU/Sr5FGjALHxvpJZNcnF1O8qIvu3mfho9HU/lno+7CFxwlmx+vADHsJ2j7GT7UGdCbwxQCXNGplxMKzBOHCBn78c93mc6E84gryjMZ88RpwmdMiSwV4EQI3K/DawoW9nXFF4LmFCUkYCVv/+JrkYFW0MOtgqvwpFGX4qHsobqzYE8mHDKeDxno3QadayXbKNOJwn+0ktl9WoDfKCipQXstd2Sz0BBtP6D3bpTdtHBRDV8hiMTTKzMhAeTrmhQHkyk9SZ/fCQNglpvkKR3tBD4x18VLN2B0dRvK0S/iaE34O+b9dc5IO+f0C0GehJDdfPPOAdYFjCx87efHsN0SbSIvJczy5AAAAAElFTkSuQmCC";
        public const string imagetextOpenLogs = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QITDyQk7xeL3AAAAY1JREFUSMet1bFrFFEQBvDf5i5qJwGbgGIZFMQ/wEIlCViYzlKQq4KooIUE7O0tgkVIk0AghJRpBK3EwsZSsLBSLCwSlRCI0TsL52A5Nvfeu8sHw+57uzvf7Mx88/iP89hFbwT7i3lDMBHXa3gX6zMFdhrPcGcYSTuu3bAeDpXhKCxJMi5uYQNVrCt8xRK6TSSdSMOwwFbwu7b3LdJd1TLzAO+x3UQyW6tVE05hC99rex/xcuC9ub6fJpK7Tg49iYhPDBPHsOfqo//9VSyUdFeFyczW7WMKF0tb+KgwI6+xXEJyD60MxwfYHEh71S92iuRGZvQ/ayT3w+AJXqRIOiM00DIeldakytVAoFU6u/ZiLKSwi5m4v4LFGEev8ClFciFTpN1aMFO4FP4+5JDsj1CTt3hcovhxJkc7RdIbYwh2opa/QmeNhT/EZTwc4SC7iXU8jS77cRzJTnTIzMBoWYjoPidEuRR/kjzjnzc8n8YbrI5TsHZGQc/iXKHfP6GZVo6yb2Mtc2A2ifU6vvwDnGNf2Vrei9cAAAAASUVORK5CYII=";
        public const string imagetextLocations = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QITDyQGOnfKOAAAAUVJREFUSMft1c0qRVEUB/DfPS6XyGdRUjIyopSBmZSHMDPgCczJQygjD2IiUwMjZaAkHyMjBlwix2Sp2+nc03GuAWXVbu+z13+v/1l7fWx+odQ61FtFWjCeSxCM4CnwtTzmJi6wj66MgRTnOI4zaQ7JIO4wEJgkD5dip+BPN/GCmRxdPx7wEXamW5VJBpwUkGyjgbXMfi9uw5MaZnFd1mhWPjIz9MQVDQfBfFy5qiRZ6cYNRoNgEWd5wKRiGtdxhfH4XsJpuwNVSS4xGetlnJQ9nGK3QH/VUjNfWbRSxnC9g8rfiCBPxV5XNquqkCQZrw9yMPeY6CQmhyV61G3M65irEhNRjD1tRiMwC2FroWpMXktg3n+yGCsF85/k2yS9P2BzLOaXvHw/ijbRLPNWF7SmviDoa1dUWxjq0JM37OGxzTP9h+UTVFlBDoFpkHkAAAAASUVORK5CYII=";
        public const string imagetextHelp = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QITDyETKt3algAAAZpJREFUSMfV1r9LlWEUB/CPv8pBJYJwK0kHl5bMP6DNIRpEwiHIIQhCSAcb+hca2oKgrUWEKGorG2rJoASliCAaWqKhwK4XRbG35dy43N73vo/XW9B3e57v9znf55zn5ZyXf4COfeoHcQQZvmKjHZc4ijmsR+AMFVTr1o9xsZXsDuFOBHmA6QJtH67hVWivppqMxIGlAn4Ah3P2h/Aenwr43xgOg6kmmgyrTfi7+IHOIkEVMyWZZnhSonmIR3nEdbxIKOce7ifoMoxqSOlCpFqGLWwm6O5hstFkLKEMNZNKgm4tYv7xON0Jh7fxM0HXhd1Gk5eYSMxkJ0F3Ou8rnMfrhMM3cD7x4U/mERvRRprhOI6VaJ5hsYg8ETeYKbnhmyb8Er6VpVkzWo7e1IgV3MrZP4UveJfS3WuC22H2PDLryNF1YQGfQ3uplVbfgysRYCDnbbbxFOcOOlN6w6QeE7E3267pOY0PdeubYTDWzhG9jsvRDd7iI/r3M7o7S/gz8dV8jxaxHEOtklPCllErTRXjf+tvpg9n/Q/4BTVMWkDW95cTAAAAAElFTkSuQmCC";
        public const string imagetextLogging = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QITDyMxzYv58AAAAZ9JREFUSMe11b9LV1EYBvDP1S8Ggk4tQTgkkqgNQUtLtEjkZJK1togu9gfUFBHUVEO1iTU0FOGsUEsRIRQ2SoVgiTo0FETYD7stp7ic7tV7v9/rO533PbznOc/z3PfcJE3TQ1i3d/G7ga0kSbZwHWnNAI+w1MgUhnAVbTUB9ON8DLKBxZIHJCVY/8Rh0a2zTV24VtD8MAfgFD7gHW7GDUXSdKCzYK87yg8GP3vQh01MlwGpEsOYyeR3cSbIVRvIC4xm8tN4jn9+N5o4NPbjLR5gNUi1Hpgca5bJMI7jclSfxQieBQDNejKBCxjAEt5E+53hg/kvqsh1EUcyM3UW+/Fpt8YqTL5H+QF8LtNYhclkMPcKTob1r1ZA8p6M1xjES4xjueztiuS6FJ6Knqj+FWtVAIpA1vAE5zCPo61OayzXCdzCQpBsAHMYawUkZvIN+zKedOR8VS0zeYV72MYKbmefhxDtO1y4rawnQ3gfBq0XH6P9GwUgy7i/G5PtzPrxDuyfFtS/BCX+xo88kKkwZElN//gu3IlB6jo815PUHscfm2JRyb9z0MAAAAAASUVORK5CYII=";
        public const string imagetextRefreshLogs = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA3XAAAN1wFCKJt4AAAAB3RJTUUH4QITDyQWJ8DaXAAAAWpJREFUSMe1lrFKA0EQhr+LojZCCsUiYJtOFBRRBGsbi6BEGxGtbH0BG1FEIorYWKQQO0mTNxACaSSglRZBAhKwEGIaG5O1mcCybO7O0VtYjmP/2W9ndm7mAmPMJJAiudHRGA0kcZIxoAh8AcaaH8DJfwAOZcOuA3Dnhhaw52z0CBwDB8AZ8Oqsn2ogy2L8DGT6aOaAtuXpdhL3FcizaYHScQxnFbAhK2zFKPGOhEcz9i1Q6OiJNpWgyGy7tkRdJaQq9he+xYwn988VkCOxrfhKRB6oA/OSMWVgGCjF3Hwc2AUWgCwwCHwCo0DDFbflJHmFF3VPNNJ4qm9TnlMKyJrzXgBaPuGlnOBFefFlSZrvMNGS5WpWARkR2/UoYUuENaU3uTiiLcubQoIdk6pV8O5CdCngHnjXghqWRx3gClgFZqTs3DoNbVELqkR0xN68+WvoVvp8aAZ4iNMagl/2jGlgAngDnrS/O4mMH6J4gCPjPWHCAAAAAElFTkSuQmCC";
        public const string imagetextDebugWindow = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAAB3RJTUUH4QITDyYuPfQAQAAAAatJREFUSMe1lrFKHFEUhr9/dhJ2ZSHJki2s3BQWqSQmFkJaCwsbSfIMvoGvYB1SpU8nJEUeIBBFC5sQEIIohIAG1kqUTXD1t5mB62UWHfbugcsMd+byzfnPuf9c2WbSkZc3kh4BK0AGjEMWcAV8sX0BINtIeg7sAP0xASGoC8zbPiohX4EZ4H9ClZrAvu13eUB2cU0VQ2A6rImBBtBOCLkopc+DBji2vSQptz2sFFpq3Cdb20NJ34AHt7qrXFy80AUeBk0gILP9p2bxVQmRtAp8Ak6jRW1JH22v14AQQ8r4AfwF/kXtbOD7WJsx0PMQeDaRHT8yZ+klsABcBtMNoG/7cxIIsFfIRyTdtKQp24MUkNfAqxGZDJJkYnsb2J5oTYLaNIHdwqWvg0dTwHvbH0atzWp80CwwB3SAp8HoAMtJMrH9s3CCx9H+yW3/qg2R1KrIUrZPK5zgzsgqAG+AM+B3NPqSNsYtvANb2QMGkUG2atqKY0gWaH8ALCb6BWchZAC8kLQGnNfsujiugSdAD9gKDxK9QqJhQl/MgDnbJwrPXZLepjoS2d4sJ24AJ7ybQ2pZyaEAAAAASUVORK5CYII=";
        public const string imagetextshowLogs = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QITDyMGdTZc/wAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAFE0lEQVRIx5XUy28bxx0H8O889r1cUlxRoizJomTLsQO7MQoFCBAE8C23tkBvyX/YS29FLjHsAklRt2iDIEEsWarkNLEefIjc9+zOzvRgyqAlU0l/wO+wh9/MYD7zXba9/d7HGxtbH+U1TUUWWQC8OW3tfPDg96/OklOg8gF493q9leWNrbv90+N85+HOp92bvR3LZKJ7Y/O9+1tbjwa1GpVJbHPXIkdRoncn/Z9GABjm1P310Fm4sf7skb9gxZU2ZJUW8eRsuGq1xcrmJtZ6689H5wP2r8OjF4927mZP/v7F1wZgAtDctcxA8+Y5AA6AzNskGQy1quqmMu2YFSnxFwImyshSWri+52mRF7ZjmBkAkhaTEoBRvV6P0Cir42+/+XIAQANQ8zrVqGspIynrXKGsnj5+cmrJqiTgUVXVhJv8LJucDgGQ/vlzMT2bAqBouBC8P/2g13UvADdN44FhuWsGo4sAwLzGAmds03Mcr5TyY+UvLAMA5+Fbs7SW1eR3f/hjCEBc1w+XUFqWLVzHE42gEQGoGg1fOI4j/MDPm36zr73lEwDyg/fbdHaWtdphHbb9oLt2e/U3t2+t7R7sn0592Gyf00W7EbYzmR+fHPdrsrG+7A/OBonJnezg5b7I86Ik0MmrH49qyqjRH0b1xSx1LDssBCFECVLoup7iX7kuPRlorVlLMa/luW7guY7PbWYrXbeCVsvZvt0zyzKhAAinhM/OcsJYNk7qrBOQKoorNQP2Vl3Aa8YKRjVqpakpspK4PNI1jOOzU3F4mlYAdC5kObsGZZSur4TGnXFqbjZbzifzHsEbeIYuCOtxxrq8ETQ5Y5vcNr2loPWgs7jgAUC3E/izN0JtyxIwWunWcjMmlIvpU54L32h4wrKc3PO8tBG8hvcaQSoZrW/evCUByE47EADKN/Cu69a2bYrRKMot8JPdg734MvosfDLuD+NURvH4bDIcRaXJnezFwQ9ifWVVHZ0Mz4c/H16B557rhZU2RNMjBAazL67xsskFPLV8zSvmOm5TFnU+UbpuhZ2lVCrFzGp8GX66GGV5rRBTSmRR5piX/DfwYAWjOquVlqbISgIeyVqTUmST/47Ly/AKgOKOobsyjf0//+3ZE6QJphm5UhfwCtVRSViLM1byRqA4YzcM2xo5trPdXWymk0MU3U7g7/3nVX7xL+SEBsQ06xJpUuKaergEcmLZgpumkBVyz+YFiC8c6gjPcNOG3yw2G+1y9x9fzcIDAJjfsMpwaT26t72xdfvudu/F3v6r6xL/Lvj9o33hGrwcjOP09KeX8gq86/iLRVmXnsVklRblzPv+9fBhmFqW7agswrvguaY0VbWW0DW3bbv85cTrnDGqldLcLF8nXkrFGWXncZzU70o8twjbLuJk9+mXj/cAgFLKlVJz4QHruFJJW3HaZ36z4oytWbY1ogbuec3VZ8D3+RV407Umi+F65/ONz5ZTFa+83B1+9e/vvh7Oh9eTsmrBd2RlsFw61BGO6WauGyTf/+VPPwPAFXjXdeuwyaofB5nwbFo8/evjQwDGNfCjOJVRNJv4/V2x2O4YBwcv+gDYOxNfVGZp64RBmyYAexrIXw3fWVpKa11dYOsriSeMZXFaxg3XHifJeHj3zo73/ya+kopIJc8vDnc58ZRTttoIgi3L5LdcL/jw+d4/R1Owt/pOCGZZ5n2Tk2VQftPgvGM0FwKD857p2I5tOr+dbqJvLDe92dn/ATnHCFTuK/xiAAAAAElFTkSuQmCC";
        public const string imagesupportCenter = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QITDyIckU+UxAAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAACb0lEQVRIx92WTWtTQRSGn5OPRtpYG7Fpgx/VCi5EqagoFHGnuOk/8me48T+4c+9eFIK0IIImVKNWhbRpPm+a5Lh5r4yXm5B1B4bJzJ1z3nnfc85M4LQ0CyfuXgZeAEfq34CfQAP4aGatNCfujpnNDXIXeAZ8AM4Bq8A6cAl4AETAb6AJdIAe8B04BKpm9jYNJJeY39DJF/VtAPwCToAdIANc1noP6AN5rTfdfdvMxkmQTGK+IcMxMFEfA23gj5iM5HgFuCimWeAgDSCNyQXgLPBOzkcCGgH7YhhKHcsdAV+mxSTJZF3OV4GheqSxJpa9YOwBxzpIfRpIksmS9D6v2BjgAv4MbGlfVj0jwKJiNxvE3dfkuCfjrGTKqB8qs/IJkGNgGTiYh8mmaqMtefJiFevuStcl2cUgcXLU5gEpS9dWEA8Pvk9UlCsBSE7JMDSzxjwgy8Ca1o4k2wA4I7CygLuBXFnZNd29EtSMA/vxLWBBTG4DdyTbFaVzSwFvA8+BgqQZJ2ppAiwEazlgw8z6SSa7ZrYrwAxQCgC3grjEbUFzD9bjGOXDvf/qJHHBTSTLfeCJ7q6ejDvAe6mQlbOBeswomlUncSsArzQuaJ9r/kMsu7ooY4Zfgcfa001lkmg3db0UlLIlnXysNL4HVIFPct4IKv91UMTTQcysCrzRdV8IEqSuGPWVutv6HQG3gJfAQx0m/T1JPkLufh14Kgc7wB7wSPJFsq/rIBXJV1L8Ns1sOBUk7cVz95qCWwlAsjq1S5WR1obA1RgkN/Nt/j/jisC1INCLge7JVD4JCdi8fwbcvSgnFoyznvWOmTmnqv0FrErc7uTAReoAAAAASUVORK5CYII=";
        public const string imagesfindTracer = "iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QITFDIuAymbhAAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAACcUlEQVRIx73VT4iVVRgG8N+9jv/SQSW6NIqoVKYurO5KCEVpIYQZhP9ol7oIIgpUqk2iSCi4aJUomtSipeBCU4QgmtICNyWMWTORqDNNlMWoME7d26Jn4PMy3flGyBcO53znO+95zvu8z3lPxb9WxWQTs+GyCzvSL8JruF3Cp4ppOIj+MiCV9GtwGluySTt7FPtwDZvwAxplwFZjoGT0C/ApVsZnVYGRtnQVo3oIs9EcI+qb8ZmOL7AW5/E6jpUBKUb1Fv5umZ+MvbiChzOu4gMcnSjIDXzWwvNolNfxG3ZlbiSHebMsXaP2Oy6Grkr629lsRnLQGWX9lPX9EwVZhG3ZdCin/RnPRYWtdgKHCgcqBXIT38bhApbjQP79iVuYFDpn46W0AXw4noR/ybiGFXgcOwLWRC9eRT3rV2BPqBpdUy8Lsh5f4gUMxnko92IJnsFTaYuxNZQ2k6NKGbquhucLeCRzp/B0Ihlp8X8l9NYxH3MihrYgw1lUK8z14CS+G0PaPyZPEk1HmUjmRUmfF+Y25f68UbikzQC+jccyN1QAHPee9OCJnP5FLEu5WZvc/ZVKPBfv5mDwFe6UARlMPqo4nmQ/ifexDudy4lqku7zFt5S6nsfZVNrdeBmXCkpr1wZS1+6xSekXYmMeommh40r6WfgI36e8/Joa1pvyU8NldGFmfL7B3XbvyZRIt9i6Wl7GzsL3duxEdyGi91IN7slJJY71jBv/obpK1NUIWDUq7M7FPJNK8E7+7ccfHYV69TU2jHVjW6y1CDbQl7q2GZ/g2bxJfTgyuuHU0DLV/dlIKgUszSMGH+Ow/8mWpD04+weEqqkBm7+YiAAAAABJRU5ErkJggg==";
        public const string imagespinUp = @"iVBORw0KGgoAAAANSUhEUgAAAA8AAAAOCAYAAADwikbvAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA7CAAAOwgEVKEqAAAAAB3RJTUUH4QMSDjoTB/U17gAAAN9JREFUKM+d0j1LgmEUh/HfE4oVlEIURERQQlub0NYQfZCWINz7CEKTq0hBBIVBL6v1AZwagpbWhrZobEmq5QRyJ0/mtd0v133+nHPzNxMoGJMaDrH6X3EWJ3jADZbTSHnUUcIW7nGFxTxhB21c4BFLA2e7eEI1rTwdEY/wjDvs42XgziZmUJR08RN93KKJ99jPsB6PviZJfnGMU8zHegU9HIzS4blI0MUC1nCWdtqQ4VdwiQbecB0jKuIjr2IlmtTAVAh1fGEvTyzjHK0Qf5jERnyWoWTYRicRRyYbR/oGvp4ji+kENkUAAAAASUVORK5CYII=";
        public const string imagespinDown = @"iVBORw0KGgoAAAANSUhEUgAAAA8AAAAOCAYAAADwikbvAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAA7CAAAOwgEVKEqAAAAAB3RJTUUH4QMSDwIMnKDu1wAAANBJREFUKM+d0jFKA0EYhuFnjQENYlLYGCSVTRoLr6B3CUi09QbpUsTKRuyCoAcIHsATiLYiWIuNJqLZNLOwDJt14wtfMzMv38zP8DdrWC/aqFWQD3GCF7xbgS3cIcUEe6vI50HM8oDdMuEYF7jGNJJTPGI/lhq4wi/mIWlBXtHNJpkxx2c4kITk+Q7v7+B52bWH+IraZjirMqQdfETyE9pFHyBPC7cY4TS3/oafssYW7jHAJuroh+ZemdjEGJdBzNjAAbaXiQmOcBOJlUn+Iy0ADxA0IikkiyAAAAAASUVORK5CYII=";
        public const string imagesZip = @"iVBORw0KGgoAAAANSUhEUgAAABkAAAAZCAYAAADE6YVjAAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QUEFCk2xp17fgAAARZJREFUSMft1r8rxVEYx/HX93YvJRQliyzKwJ0NSv4Ispr8AbKIf4KJxULxHxgsMigZlYWExEAky0V+LefW8U3cvt+blPuZznmeOu8+p/M850l8Vhl7OEEiu5qxiel0IsEgFuVXH5aqm2KUWMYQ7rCb8fASrjETB2PIOyZwnMNBG9bTwUJq35TzmkpfBQt+QQ1IA9KA/BFI8Yd8V2h2FRyFFr6DyZBfwUVeJ/ehO7egB7MYwDNWsVEPJy/owAiGMYU3jKIdt/WAdIa/pRycVN1vYw2X9YC0Yg7juMI8DnFWK6AWyDkW/m2dPOEhnnbSkMdocsmiCsZwEL+8IvbDujcUWRIKD/rDk33FaTQsdH8DusFWmN3AB/WOMKBTcgXwAAAAAElFTkSuQmCC";
        
        // Sayings

        private static readonly List<string> c_Sayings = new List<string>()
        {
            "A log a day helps with rest, work and play",
            "All logs and no play makes Jack a dull admin",
            "All play and no log reading makes Jack work overtime",
            "Red and Yellow make a real admins belly turn",
            "Looking at logs can be considered a sport",
            "I'm sorry Dave, I'm afraid I can't do that",
            "Of all the gin joints in all the towns in all the world, the logs walks into mine.",
            "A log walks into a bar, asks for an Error with a good head, and a few shots of Warning",
            "Here to kick log and chew bubblegum, and I'm all out of gum",
            "50 years from now, when you're looking back at your life, don't you want to be able to say you had the guts to look at a log?",
            "Conan on life: To crush your enemies, to see their logs driven before you, and to hear the lamentations of their admins",
            "The scientists of today think deeply instead of clearly. One must be sane to think clearly, but one can think deeply and be quite insane - Tesla.",
            "The harness of waterfalls is the most economical method known for drawing energy from the sun - Tesla",
            "The ear is the avenue to the heart - Voltaire",
            "No problem can withstand the assault of sustained thinking - Voltaire",
            "The single biggest problem in communication is the illusion that it has taken place - Shaw",
            "No question is so difficult to answer as that to which the answer is obvious - Shaw",
            "Success does not consist in never making mistakes but in never making the same one a second time - Shaw",
            "He who does not understand your silence will probably not understand your words, or your logs - Elbert Hubbard",
            "One machine can do the work of fifty ordinary men. No machine can do the work of one extraordinary man - Elbert Hubbard",
            "Any sufficiently advanced technology is indistinguishable from magic - Arthur C. Clarke",
            "We are in an electronic technology age now and it's about time we put away the old stuff - Monica Edwards",
            "A new broom sweeps clean but an old broom knows the corners.",
            "Common sense is genius dressed in its working clothes - Ralph Waldo Emerson",
            "Give a man a fish and you feed him for a day; teach a man to fish and he'll eat forever.",
            "Just because something is common sense doesn't mean it's common practice",
            "When in Rome, do as the Romans",
            "The squeaky wheel gets the grease",
            "The pen is mightier than the sword",
            "Two wrongs don't make a right",
            "When the going gets tough, the tough get going",
            "No man is an island",
            "Fortune favors the bold",
            "People who live in glass houses should not throw stones",
            "Hope for the best, but prepare for the worst",
            "Better late than never",
            "Birds of a feather flock together",
            "Keep your friends close and your enemies closer",
            "A picture is worth a thousand words",
            "There's no such thing as a free lunch",
            "There's no place like home",
            "Discretion is the greater part of valor",
            "The early bird catches the worm",
            "Never look a gift horse in the mouth",
            "You can't make an omelet without breaking a few eggs",
            "You can't always get what you want",
            "A watched pot never boils",
            "Beggars can't be choosers",
            "Actions speak louder than words",
            "If it ain't broke, don't fix it",
            "Practice makes perfect",
            "Too many cooks spoil the broth",
            "Easy come, easy go",
            "Don't bite the hand that feeds you",
            "All good things must come to an end",
            "If you can't beat 'em, join 'em",
            "One man's trash is another man's treasure",
            "There's no time like the present",
            "Beauty is in the eye of the beholder",
            "Necessity is the mother of invention",
            "A penny saved is a penny earned",
            "Familiarity breeds contempt",
            "You can't judge a book by its cover",
            "Good things come to those who wait",
            "Don't put all your eggs in one basket",
            "Two heads are better than one",
            "The grass is always greener on the other side of the hill",
            "Do unto others as you would have them do unto you",
            "A chain is only as strong as its weakest link",
            "Honesty is the best policy",
            "Absence makes the heart grow fonder",
            "You can lead a horse to water, but you can't make him drink",
            "Don't count your chickens before they hatch",
            "If you want something done right, you have to do it yourself",
            "A broken clock is right twice a day"
        };

        // Switches 

        private bool globalautoswitchlogsPanel = true;

        private bool afterselectDisabled = false; // Enable\Disable the treeview afterselect eventing

        private bool visualEffects = true; // Visual effects switch - On by default and used for the TreeView Slider effect, but will b e disabled if RDP detected

        private bool zipthreadRunning = false; // Switch for when Zip thread runs        

        private string TracerPath = null; // The path to the Tracer used when launching logs

        private bool disabletreeView = false; // Allow for disabling treeview code execution, used when updating the treeview during a scan

        private bool switches_monitorLogs = false; // Trigger for stopping the monitoring background worker thread

        private bool switches_Slider = false; // Trigger for stopping the slider worker thread       

        private bool switches_pin_Slider = true; // Pin for slider        

        public bool switches_threadRunning = false; // Monitoring thread observation

        public bool switches_slider_threadRunning = false; // Slider thread observation

        public bool switches_logging_threadRunning = false; // Trigger for stopping the SCCM/ConfigMgr Site and Client logging thread

        private bool switches_hide_archiveLogs = false; // Switch for hiding archive logs (filemask *.lo_)

        private bool switches_open_multipleLogs = true; // Switch for controlling whether multople logs are opened in individual tracers or passed to the tracer to merge\multi

        private bool siteserverDetected = false; // Switches for SCCM Site and SCCM Client detection

        private bool clientDetected = false; // Switches for SCCM Site and SCCM Client detection

        private bool switches_scan_threadRunning = false; // Scan thread observation

        // Constants       

        private const string c_productVersion = "V3.6";
        private const string c_productTitle = "LogLauncher - " + c_productVersion;
        private const string logfileExtension = "*.lo*";
        public static readonly string[] c_colourWheel = { "FF2D3AF7", "FF3E4AF7", "FF4F5AF7", "FF606BF7", "FF7C84F7", "FF9299F7", "FFC6C9F7", "FFDFE0F7", "FFE6E7F5" };
        private const string c_archiveLog = "Archive Log";
        private const string c_activeLog = "Active Log";
        private const string c_activelog_Extension = ".log"; // Do not modify
        private const string c_archivelog_Extension = ".lo_"; // Do not modify
        private const string c_Notification = "Notification";
        private const string c_Diagnostic = "Diagnostic";

        // Variables

        private int globalfontSize = 9;

        private string globalfontName = "Arial";

        private logitemCollection globallogitemCollection = new logitemCollection(); // LogItem collection used to store logs that are discovered during a scan

        private loggingpaneldevicesCollection globalloggingpaneldevicesCollection = new loggingpaneldevicesCollection(); // Logging feature collection for devices that have client or server detected        

        private logdescriptionItemCollection globallogdescriptionItemCollection = new logdescriptionItemCollection(); // Hint collection used to store the hints defined in the array logHints        

        private List<string> monitortargetList = new List<string>();

        private int throttleDelay = 0; // Monitoring delay in seconds

        private Color gradientcolourStart = new Color(); // Gradient start colour

        private Color gradientcolourEnd = new Color(); // Gradient end colour

        private List<Color> colourList = new List<Color>(); // Gradient pallete

        public static string cmdlinedeviceName = ""; // Define a global for the device name override, used when cmd line arguments are present

        public static string supportcenterPath = ""; // Configuration Manager Support Center path

        private DateTime searchkeypressLast; // Search keypress last event date for dgv_Logs

        private string searchkeypressText; // Search keypress string for dgv_Logs

        // Classes

        public class servicecycleMessage
        {
            public string remoteServer { get; set; }
            public string serviceName { get; set; }
        }

        public class loggingMessage
        {
            public string messageType { get; set; }
            public string messageText { get; set; }
        }

        public class reportSuffixUpdatedRows
        {
            public string suffixText { get; set; }
            public logitemCollection updatedRows { get; set; }
            public string additionalText { get; set; }
        }

        public class messageObject
        {
            public string logType { get; set; }
            public string logMessage { get; set; }
        }

        public class controlConfig
        {
            public string remoteServer { get; set; }
            public string pathAppend { get; set; }
            public string pathFilter { get; set; }
            public bool recurseDirectory { get; set; }
            public string fileMask { get; set; }
            public bool disregardduplicatePath { get; set; }
            public string fileextensionOverride { get; set; }
            public string logClass { get; set; }
            public string logProduct { get; set; }
        }

        public class custombladeConfig
        {
            public string logPath { get; set; }
        }

        public class registrybladeConfig
        {
            public string registryHive { get; set; }
            public string registryvalidationPath { get; set; }
            public string registryvalidationkey { get; set; }
            public string registryPath { get; set; }
            public string registryValue { get; set; }
        }

        public class xmlbladeConfig
        {
            public string configfilePath { get; set; }
            public string searchPattern { get; set; }
            public string searchProperty { get; set; }
            public bool searchcaseSensitive { get; set; }
        }

        public class combinedConfig
        {
            public object abladeConfig { get; set; }
            public controlConfig acontrolConfig { get; set; }
        }        

        public class filenamecollectioncombinedConfig
        {
            public string fileName { get; set; }
            public logitemCollection alogitemCollection{ get; set; }
        }        

        public class combinedconfigCollection : System.Collections.CollectionBase
        {
            public void Add(combinedConfig acombinedConfig)
            {
                List.Add(acombinedConfig);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public combinedConfig Item(int Index)
            {
                return (combinedConfig)List[Index];
            }
        }
        
        public class loggingpanelDevice        
        {
            public string deviceName { get; set; }
            public string loggingType{ get; set; }
        }

        public class loggingpaneldevicesCollection : System.Collections.CollectionBase
        {
            public void Add(loggingpanelDevice aloggingpanedDevicesItem)
            {
                List.Add(aloggingpanedDevicesItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public loggingItem Item(int Index)
            {
                return (loggingItem)List[Index];
            }

            public bool Contains(loggingpanelDevice suppliedloggingItem)
            {
                foreach(loggingpanelDevice aloggingItem in List)
                {
                    if (aloggingItem.deviceName == suppliedloggingItem.deviceName && aloggingItem.loggingType == suppliedloggingItem.loggingType)
                    {
                        return true;
                    }
                }

                return false;
            }
        }        

        public class loggingItem
        {
            public string componentName { get; set; }
            public bool debugLogging { get; set; }
            public bool Enabled { get; set; }
            public int loggingLevel { get; set; }
            public int logmaxHistory { get; set; }
            public int maxfileSize { get; set; }
        }

        public class loggingitemCollection : System.Collections.CollectionBase
        {
            public void Add(loggingItem aloggingItem)
            {
                List.Add(aloggingItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public loggingItem Item(int Index)
            {
                return (loggingItem)List[Index];
            }
        }

        public class logDefinition
        {
            public string LogFolderPath { get; set; }
            public string LogClass { get; set; }
            public string LogProduct { get; set; }
            public string FullLogName { get; set; }
            public string Extension { get; set; }
        }

        public class logDefinitionCollection : System.Collections.CollectionBase
        {
            public void Add(logDefinition alogDefinition)
            {
                List.Add(alogDefinition);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public string Contains(string logfolderPath)
            {
                foreach (logDefinition alogDefinition in List)
                {
                    if (alogDefinition.LogFolderPath == logfolderPath)
                    {
                        return List.IndexOf(alogDefinition).ToString();
                    }
                }

                return null;
            }

            public logDefinition Item(int Index)
            {
                return (logDefinition)List[Index];
            }
        }

        public class logItem
        {
            public string logDevice { get; set; }
            public string logProduct { get; set; }
            public string fulllogName { get; set; }
            public string logClass { get; set; }
            public string LogName { get; set; }
            public string logType { get; set; }
            public string logLocation { get; set; }
            public long logSize { get; set; }
            public DateTime loglastModified { get; set; }
        }

        public class logitemCollection : System.Collections.CollectionBase
        {
            public void Add(logItem alogItem)
            {
                List.Add(alogItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public logItem Item(int Index)
            {
                return (logItem)List[Index];
            }

            public string Contains(string fulllogName)
            {
                foreach (logItem alogItem in List)
                {
                    if (alogItem.fulllogName == fulllogName)
                    {
                        return List.IndexOf(alogItem).ToString();
                    }
                }

                return null;
            }

            public bool Update(logItem logitemtoUpdate)
            {
                foreach (logItem alogItem in List)
                {
                    if (alogItem.fulllogName == logitemtoUpdate.fulllogName)
                    {
                        alogItem.loglastModified = logitemtoUpdate.loglastModified;
                        alogItem.logSize = logitemtoUpdate.logSize;

                        return true;
                    }
                }

                return false;
            }
        }

        public class logdescriptionItem
        {
            public string LogFilename { get; set; }
            public string LogMessage1 { get; set; }
            public string LogMessage2 { get; set; }
        }

        public class logdescriptionItemCollection : System.Collections.CollectionBase
        {
            public void Add(logdescriptionItem alogdescriptionItem)
            {
                List.Add(alogdescriptionItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public logdescriptionItem Item(int Index)
            {
                return (logdescriptionItem)List[Index];
            }

            public string Contains(string logName)
            {
                foreach (logdescriptionItem alogdescriptionItem in List)
                {
                    if (alogdescriptionItem.LogFilename.ToLower().Contains(logName.ToLower()))
                    {
                        return List.IndexOf(alogdescriptionItem).ToString();
                    }
                }
                return null;
            }
        }

        // Theme classes


        // To be implemented post-V3.5


        // Code

        private void dispatchMessage(string theType, string theMessage, object sender)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            messageObject amessageObject = new messageObject();

            amessageObject.logType = theType;

            amessageObject.logMessage = theMessage;

            worker.ReportProgress(0, amessageObject);
        }

        private void notificationMessage(string theMessage, Color backgroundColour)
        {
            toolStripStatusLabel1.Text = theMessage;

            toolStripStatusLabel1.ForeColor = Color.Black;

            toolStripStatusLabel1.BackColor = backgroundColour;

            statusStrip1.Refresh();
        }

        private void notificationMessage(string theMessage, Color thetextColor, Color backgroundColour)
        {
            toolStripStatusLabel1.Text = theMessage;

            toolStripStatusLabel1.ForeColor = thetextColor;

            toolStripStatusLabel1.BackColor = backgroundColour;
            
            statusStrip1.Refresh();
        }

        private void diagnosticMessage(string theMessage)
        {
            try
            {
                DataGridViewRow newRow = (DataGridViewRow)dgv_Diagnostics.Rows[0].Clone();

                newRow.Cells[0].Value = theMessage;

                dgv_Diagnostics.Rows.Add(newRow);
            }
            catch (Exception) // Handle this being the first row in the DGV
            {
                // Create a row so we can clone it then alter its properties, before clearing the rows and adding it again (we get the row with correct columns)

                try
                {
                    dgv_Diagnostics.Rows.Add(theMessage);

                    DataGridViewRow newRow = (DataGridViewRow)dgv_Diagnostics.Rows[0].Clone();

                    dgv_Diagnostics.Rows.Clear();

                    newRow.Cells[0].Value = theMessage;

                    dgv_Diagnostics.Rows.Add(newRow);
                }
                catch (Exception)
                {

                }
            }
        }

        private void getcommandlineParameters() // If a parameter is specified, treat it as if it is a server name
        {
            try
            {
                string[] theArguments = Environment.GetCommandLineArgs();

                foreach (string anArgument in theArguments)
                {
                    if (!anArgument.Contains(".exe"))
                    {
                        if (anArgument != "" || anArgument != null)
                        {
                            // Set the device name override to the command line supplied

                            cmdlinedeviceName = anArgument.ToUpper();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void populateserverMRU()
        {
            // Recent servers list

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers"))
                {
                    string[] recentServers = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers");

                    try
                    {
                        rcb_remoteServer.DropDownItems.Clear();

                        foreach (string recentServer in recentServers)
                        {
                            RibbonTextBox aribbontextBox = new RibbonTextBox();

                            aribbontextBox.TextBoxText = recentServer.ToUpper();
                            aribbontextBox.Text = recentServer.ToUpper();
                            aribbontextBox.Value = recentServer.ToUpper();

                            aribbontextBox.AllowTextEdit = false;

                            rcb_remoteServer.DropDownItems.Add(aribbontextBox);

                            rcb_remoteServer.SelectedValue = recentServer.ToUpper();

                            rcb_remoteServer.SelectedItem = aribbontextBox;
                        }
                    }

                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void getloglauncherSettings()
        {
            // HKLM - Create LogLauncher registry settings if they do not already exist

            try
            {
                if (!regkeyExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall"))
                {
                    RegistryKey companyReg = Registry.LocalMachine.OpenSubKey("Software", true);

                    companyReg.CreateSubKey("SMSMarshall");
                }

                if (!regkeyExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher"))
                {
                    RegistryKey logLauncherKey = Registry.LocalMachine.OpenSubKey(@"Software\SMSMarshall", true);

                    logLauncherKey.CreateSubKey("LogLauncher");
                }
            }
            catch (Exception)
            {

            }

            // HKCU - Create LogLauncher registry settings if they do not already exist

            try
            {
                if (!regkeyExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall"))
                {
                    RegistryKey companyReg = Registry.CurrentUser.OpenSubKey("Software", true);

                    companyReg.CreateSubKey("SMSMarshall");
                }

                if (!regkeyExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher"))
                {
                    RegistryKey logLauncherKey = Registry.CurrentUser.OpenSubKey(@"Software\SMSMarshall", true);

                    logLauncherKey.CreateSubKey("LogLauncher");
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not create the LogLauncher registry keys to store your preferences - " + ee.Message);
            }

            // HKCU User Preferences 

            // Zip output folder

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "ZIPOutputFolder"))
                {
                    rtb_zipoutputDirectory.TextBoxText = getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "ZIPOutputFolder").ToString();
                    
                }
                else
                {
                    rtb_zipoutputDirectory.TextBoxText = @"C:\WINDOWS\TEMP";                    

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "ZIPOutputFolder", rtb_zipoutputDirectory.TextBoxText);

                }
            }
            catch (Exception)
            {

            }

            // Monitoring Timer Duration

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MonitoringTimerDuration"))
                {
                    rup_Duration.Value = getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MonitoringTimerDuration").ToString();
                    rup_Duration.TextBoxText = rup_Duration.Value;
                }
                else
                {
                    rup_Duration.Value = "5";
                    rup_Duration.TextBoxText = "5";

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MonitoringTimerDuration", "5");

                }
            }
            catch (Exception)
            {

            }

            // Gradient Start Colour

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientStartColour"))
                {
                    rcc_Newest.Color = Color.FromArgb(Convert.ToInt32(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientStartColour")));
                }
                else
                {
                    rcc_Newest.Color = Color.FromArgb(Convert.ToInt32("ff1dacf1", 16));

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "GradientStartColour", rcc_Newest.Color.ToArgb().ToString());
                }
            }
            catch (Exception)
            {

            }

            // Gradient End Colour

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientEndColour"))
                {
                    rcc_Oldest.Color = Color.FromArgb(Convert.ToInt32(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientEndColour")));
                }
                else
                {
                    rcc_Oldest.Color = Color.FromArgb(Convert.ToInt32("ffeeffff", 16));

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "GradientEndColour", rcc_Oldest.Color.ToArgb().ToString());
                }
            }
            catch (Exception)
            {

            }

            // Multiple or Merged Logs Single Trace

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MultiMergeSingleTrace"))
                {
                    rcb_MultiMerge.Checked = Convert.ToBoolean(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MultiMergeSingleTrace"));
                }
                else
                {
                    rcb_MultiMerge.Checked = true;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MultiMergeSingleTrace", rcb_MultiMerge.Checked.ToString());
                }
            }
            catch (Exception)
            {

            }

            // Font

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "Font"))
                {
                    globalfontName = getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "Font").ToString();
                }
                else
                {
                    globalfontName = "Arial";

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "Font", "Arial");
                }
            }
            catch (Exception)
            {

            }

            // Font Size

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "FontSize"))
                {
                    globalfontSize = Convert.ToInt16(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "FontSize"));
                }
                else
                {
                    globalfontSize = 9;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "FontSize", "9");
                }
            }
            catch (Exception)
            {

            }

            // Hide Archive Logs

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "HideArchiveLogs"))
                {
                    rcb_hidearchiveLogs.Checked = Convert.ToBoolean(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "HideArchiveLogs"));
                }
                else
                {
                    rcb_hidearchiveLogs.Checked = true;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "HideArchiveLogs", rcb_hidearchiveLogs.Checked.ToString());
                }
            }
            catch (Exception)
            {

            }
        }

        private void updateloglauncherSettings(RegistryHive regHive, string regvalueName, string regvalueValue)
        {
            if (regHive == RegistryHive.LocalMachine)
            {
                try
                {
                    RegistryKey aregKey = Registry.LocalMachine.OpenSubKey(@"Software\SMSMarshall\LogLauncher", true);

                    aregKey.SetValue(regvalueName, regvalueValue);
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not create preferences registry key value " + regvalueName + " - " + ee.Message);
                }
            }
            else
            {
                try
                {
                    RegistryKey aregKey = Registry.CurrentUser.OpenSubKey(@"Software\SMSMarshall\LogLauncher", true);

                    aregKey.SetValue(regvalueName, regvalueValue);
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not create preferences registry key value " + regvalueName + " - " + ee.Message);
                }
            }
        }

        private bool regkeyvalueExist(string remoteServer, string regClass, string regKey, string regValue)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                remoteHK = remoteHK.OpenSubKey(regKey);

                Object regResult = remoteHK.GetValue(regValue);

                remoteHK.Close();

                if (regResult == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool regkeyExist(string remoteServer, string regClass, string regKey)
        {
            try
            {
                string regPath = regKey.Substring(regKey.LastIndexOf(@"\") + 1, (regKey.Length) - regKey.LastIndexOf(@"\") - 1);

                string regName = regKey.Substring(0, regKey.LastIndexOf(@"\"));

                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                remoteHK = remoteHK.OpenSubKey(regKey);

                if (remoteHK == null)
                {
                    return false;
                }
                else
                {
                    remoteHK.Close();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void dgvAdd(string logProduct, string fulllogName, string logClass, string cleanedlogName, string cmagentlogLocation, string logType, long logfileSize, DateTime loglastModified, bool isVisible)
        {
            try
            {
                DataGridViewRow newRow = (DataGridViewRow)dgv_Logs.Rows[0].Clone();
                
                newRow.DefaultCellStyle.Font = new Font(globalfontName, globalfontSize, FontStyle.Regular);

                newRow.Cells[0].Value = fulllogName;
                newRow.Cells[1].Value = cleanedlogName;
                newRow.Cells[2].Value = logClass;
                newRow.Cells[3].Value = logType;
                newRow.Cells[4].Value = logfileSize;
                newRow.Cells[5].Value = logfileSize / 1024 / 1024;
                newRow.Cells[6].Value = loglastModified;

                newRow.Cells[7].Value = fulllogName.Substring(0, fulllogName.LastIndexOf(@"\"));

                newRow.Cells[8].Value = logProduct;

                newRow.Visible = true;

                // Check if this log has an associated log hint

                string alogdescriptionIndex = globallogdescriptionItemCollection.Contains(cleanedlogName);

                if (alogdescriptionIndex != null)
                {
                    foreach (DataGridViewCell aCell in newRow.Cells)
                    {
                        try
                        {
                            logdescriptionItem alogdescriptionItem = globallogdescriptionItemCollection.Item(Convert.ToInt16(alogdescriptionIndex));

                            aCell.ToolTipText = alogdescriptionItem.LogMessage1;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }

                dgv_Logs.Rows.Add(newRow);
            }
            catch (Exception) // Handle this being the first row in the DGV
            {
                // Create a row so we can clone it then alter its properties, before clearing the rows and adding it again

                dgv_Logs.Rows.Add(fulllogName, logClass, cleanedlogName, cmagentlogLocation, logType, logfileSize, logfileSize / 1024 / 1024, loglastModified);

                DataGridViewRow newRow = (DataGridViewRow)dgv_Logs.Rows[0].Clone();

                newRow.DefaultCellStyle.Font = new Font(globalfontName, globalfontSize, FontStyle.Regular);

                dgv_Logs.Rows.Clear();

                newRow.Cells[0].Value = fulllogName;
                newRow.Cells[1].Value = cleanedlogName;
                newRow.Cells[2].Value = logClass;
                newRow.Cells[3].Value = logType;
                newRow.Cells[4].Value = logfileSize;
                newRow.Cells[5].Value = logfileSize / 1024 / 1024;
                newRow.Cells[6].Value = loglastModified;
                newRow.Cells[7].Value = fulllogName.Substring(0, fulllogName.LastIndexOf(@"\")); ;
                newRow.Cells[8].Value = logProduct;

                if (isVisible)
                {
                    newRow.Visible = true;
                }
                else
                {
                    newRow.Visible = false;
                }

                dgv_Logs.Rows.Add(newRow);
            }
        }

        private string[] getregkeyValues(string remoteServer, string regClass, string regPath)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath);

                    if (hk != null)
                    {
                        string[] regResult = hk.GetValueNames();

                        if (regResult != null)
                        {
                            return regResult;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        private bool setregkeyValues(string remoteServer, string regClass, string regPath, string regValue, string[] regValues)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath, true);

                    if (hk != null)
                    {
                        hk.SetValue(regValue, regValues, RegistryValueKind.MultiString);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        private RegistryHive returnregistryHive(string registryClass)
        {
            if (registryClass == "HKEY_LOCAL_MACHINE")
            {
                return RegistryHive.LocalMachine;
            }

            if (registryClass == "HKEY_CURRENT_USER")
            {
                return RegistryHive.CurrentUser;
            }

            return RegistryHive.LocalMachine; // Fallback to HKLM 
        }

        private object getregkeyValue(string remoteServer, string regClass, string regPath, string regKey)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath);

                    if (hk != null)
                    {
                        Object regResult = hk.GetValue(regKey);

                        if (regResult != null)
                        {
                            return regResult;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        private logitemCollection refreshlogsinDataset(logitemCollection refreshthelogItems)
        {
            // Get a list of the log folders that need monitoring to be performed on them

            List<string> logpathstoMonitor = new List<string>();

            List<string> logfileExtensions = new List<string>();

            logDefinitionCollection alogdefinitionCollection = new logDefinitionCollection();

            // Retrieve the unique log folders, and store the logs as a definition object to work on later

            try
            {
                foreach (logItem alogItem in refreshthelogItems)
                {
                    if (!logpathstoMonitor.Contains(alogItem.logLocation))
                    {
                        logpathstoMonitor.Add(alogItem.logLocation);

                        logfileExtensions.Add(Path.GetExtension(alogItem.fulllogName));
                    }

                    logDefinition alogDefinition = new logDefinition();

                    alogDefinition.LogFolderPath = alogItem.logLocation;
                    alogDefinition.LogClass = alogItem.logClass;
                    alogDefinition.LogProduct = alogItem.logProduct;
                    alogDefinition.FullLogName = alogItem.fulllogName;
                    alogDefinition.Extension = Path.GetExtension(alogItem.fulllogName);

                    alogdefinitionCollection.Add(alogDefinition);
                }

            }
            catch (Exception)
            {
            }

            // Refresh existing logs, and remove deleted logs

            List<int> logitemstoRemove = new List<int>();

            List<int> globallogitemstoRemove = new List<int>();

            foreach (logItem alogItem in refreshthelogItems)
            {
                try
                {
                    FileInfo thefileInfo = new FileInfo(alogItem.fulllogName);

                    if (alogItem.loglastModified.ToString() != thefileInfo.LastWriteTime.ToString())
                    {
                        alogItem.logSize = thefileInfo.Length;

                        alogItem.loglastModified = thefileInfo.LastWriteTime;

                        foreach (logItem updatelogItem in globallogitemCollection)
                        {
                            if (updatelogItem.fulllogName == alogItem.fulllogName)
                            {
                                updatelogItem.loglastModified = thefileInfo.LastWriteTime;

                                updatelogItem.logSize = thefileInfo.Length;

                                break;
                            }
                        }
                    }
                }
                catch (Exception ee) // File most likely no longer exists so handle the exception
                {
                    if (ee.Message.ToString().ToLower().Contains("could not find file")) // Remove the log entry
                    {
                        logitemstoRemove.Add(Convert.ToInt16(refreshthelogItems.Contains(alogItem.fulllogName)));

                        int globalogIndex = Convert.ToInt32(globallogitemCollection.Contains(alogItem.fulllogName));

                        globallogitemCollection.RemoveAt(globalogIndex); // Remove from global dataset
                    }
                }
            }

            try
            {
                logitemstoRemove.Reverse();

                foreach (int itemIndex in logitemstoRemove)
                {
                    refreshthelogItems.Remove(itemIndex);
                }
            }
            catch (Exception)
            {

            }

            // Add new logs

            foreach (string logpathtoMonitor in logpathstoMonitor) // Iterate over each unique log folder
            {
                foreach (string logExtension in logfileExtensions)
                {
                    // Get the log files from logpathtoMonitor with the logExtension file extension

                    try
                    {
                        DirectoryInfo alogFolder = new DirectoryInfo(logpathtoMonitor);

                        // Get the files from the log location

                        FileInfo[] theFiles = alogFolder.GetFiles("*" + logExtension);

                        // Now check if there are any in the file list that are not in the existing collection

                        foreach (FileInfo aFile in theFiles)
                        {
                            try
                            {
                                if (refreshthelogItems.Contains(aFile.FullName) == null) // Is this a new file
                                {
                                    logItem newlogItem = new logItem();

                                    newlogItem.fulllogName = aFile.FullName;

                                    // Get the first instance of alogdefinitionCollection to retrieve some properties from it

                                    logDefinition alogDefinition = new logDefinition();

                                    try
                                    {
                                        alogDefinition = alogdefinitionCollection.Item(0);
                                    }
                                    catch (Exception)
                                    {

                                    }

                                    if (alogDefinition.LogClass == null)
                                    {
                                        newlogItem.logClass = "FailedLookup";
                                        newlogItem.logProduct = "FailedLookup";
                                    }
                                    else
                                    {
                                        newlogItem.logClass = alogDefinition.LogClass;
                                        newlogItem.logProduct = alogDefinition.LogProduct;
                                    }

                                    if (aFile.Name.Substring(aFile.Name.Length - c_archivelog_Extension.Length, c_archivelog_Extension.Length) == c_archivelog_Extension)
                                    {
                                        newlogItem.logType = "Archive Log";
                                    }
                                    else
                                    {
                                        newlogItem.logType = "Active Log";
                                    }

                                    newlogItem.loglastModified = aFile.LastWriteTime;

                                    newlogItem.logLocation = aFile.FullName.Replace(@"\" + aFile.Name, "");

                                    string cleanedlogName = aFile.Name.ToLower().Replace(Path.GetExtension(aFile.Name), "");

                                    newlogItem.LogName = cleanedlogName;

                                    newlogItem.logSize = aFile.Length;

                                    refreshthelogItems.Add(newlogItem); // Add the log to the local dataset

                                    globallogitemCollection.Add(newlogItem); // Add the log to the global dataset
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return refreshthelogItems;
        }

        private logitemCollection fetchLogs(combinedconfigCollection acombinedconfigCollection, logitemCollection existinglogitemCollection, object sender)
        {
            // Log path history

            List<string> logpathHistory = new List<string>();

            try
            {
                foreach (combinedConfig acombinedConfig in acombinedconfigCollection)
                {
                    try
                    {
                        List<string> fetchedlogLocations = new List<string>();

                        controlConfig acontrolConfig = new controlConfig();

                        xmlbladeConfig axmlbladeConfig = new xmlbladeConfig();

                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        if (acombinedConfig.acontrolConfig is controlConfig) // Handle the Control blade
                        {
                            acontrolConfig = (controlConfig)acombinedConfig.acontrolConfig;
                        }

                        // I call this the XML blade code, but I'm actually parsing the XML file as if it was a TXT file as I only do this for one of the multitude of tests, i'll come back to this when needed

                        if (acombinedConfig.abladeConfig is xmlbladeConfig) // Handle the XML Blade - Note that I don't deal with XML in an orthodox way, I do it Conan style, brute force using pattern matching
                        {
                            axmlbladeConfig = (xmlbladeConfig)acombinedConfig.abladeConfig;

                            object systembootDrive = getregkeyValue(acontrolConfig.remoteServer, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Setup", "BootDir");

                            var configfileContent = File.ReadLines(axmlbladeConfig.configfilePath);

                            foreach (string currentLine in configfileContent)
                            {
                                bool triggerScan = false; // Our trigger for determining if we have to look for the property

                                if (axmlbladeConfig.searchcaseSensitive)
                                {
                                    if (currentLine.Contains(axmlbladeConfig.searchPattern))
                                        triggerScan = true;
                                }
                                else
                                {
                                    if (currentLine.ToLower().Contains(axmlbladeConfig.searchPattern.ToLower()))
                                        triggerScan = true;
                                }

                                if (triggerScan)
                                {
                                    triggerScan = false; // Reset so we can have another go

                                    if (axmlbladeConfig.searchcaseSensitive)
                                    {
                                        if (currentLine.Contains(axmlbladeConfig.searchPattern))
                                            triggerScan = true;
                                    }
                                    else
                                    {
                                        if (currentLine.ToLower().Contains(axmlbladeConfig.searchProperty.ToLower()))
                                            triggerScan = true;
                                    }

                                    if (triggerScan)
                                    {
                                        // We've got a property match

                                        string iislogfilePath = "";

                                        int findProperty = currentLine.IndexOf(axmlbladeConfig.searchProperty) + axmlbladeConfig.searchProperty.Length + 1;

                                        string cut1 = currentLine.Substring(findProperty, currentLine.Length - findProperty);

                                        for (int i = 0; i < cut1.Length; i++)
                                        {
                                            if (cut1.Substring(i, 1) == ((char)34).ToString())
                                            {
                                                iislogfilePath = cut1.Substring(0, i);

                                                break;
                                            }
                                        }

                                        iislogfilePath = iislogfilePath.ToLower().Replace(@"%systemdrive%\", systembootDrive.ToString());

                                        if (iislogfilePath != "" || iislogfilePath != null)
                                        {
                                            if (!fetchedlogLocations.Contains(iislogfilePath))
                                            {
                                                if (acontrolConfig.remoteServer != "") // Convert to UNC
                                                {
                                                    if (!fetchedlogLocations.Contains(@"\\" + acontrolConfig.remoteServer + @"\" + iislogfilePath.Substring(0, 1) + @"$\" + iislogfilePath.Substring(3, iislogfilePath.Length - 3)))
                                                    {
                                                        fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + iislogfilePath.Substring(0, 1) + @"$\" + iislogfilePath.Substring(3, iislogfilePath.Length - 3)); // ????
                                                    }
                                                }
                                                else
                                                {
                                                    fetchedlogLocations.Add(iislogfilePath);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (acombinedConfig.abladeConfig is custombladeConfig) // Handle the custom Blade
                        {
                            custombladeConfig acustombladeConfig = (custombladeConfig)acombinedConfig.abladeConfig;

                            if (acontrolConfig.remoteServer != "") // Convert to UNC
                            {
                                if (acustombladeConfig.logPath != "" || acustombladeConfig.logPath != null)
                                {
                                    fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + acustombladeConfig.logPath);
                                }
                            }
                            else
                            {
                                fetchedlogLocations.Add(acustombladeConfig.logPath);
                            }
                        }

                        if (acombinedConfig.abladeConfig is registrybladeConfig) // Handle the Registry Blade
                        {
                            aregistrybladeConfig = (registrybladeConfig)acombinedConfig.abladeConfig;

                            if (regkeyExist(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryvalidationPath))
                            {
                                if (regkeyvalueExist(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryPath, aregistrybladeConfig.registryValue))
                                {
                                    string afetchedlogLocation = getregkeyValue(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryPath, aregistrybladeConfig.registryValue).ToString();

                                    if (acontrolConfig.remoteServer != "") // Convert to UNC
                                    {
                                        if (afetchedlogLocation != "" || afetchedlogLocation != null)
                                        {
                                            fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + afetchedlogLocation.Substring(0, 1) + @"$\" + afetchedlogLocation.Substring(3, afetchedlogLocation.Length - 3)); // ????
                                        }
                                    }
                                    else
                                    {
                                        fetchedlogLocations.Add(afetchedlogLocation);
                                    }
                                }
                            }
                        }

                        foreach (string fetchedloglocationValue in fetchedlogLocations)
                        {
                            string fetchedlogLocation = fetchedloglocationValue;

                            if (acontrolConfig.logClass.ToString().ToLower().EndsWith("logs"))
                            {
                                dispatchMessage(c_Notification, "Fetching " + acontrolConfig.logClass + " for product " + acontrolConfig.logProduct, sender);
                            }
                            else
                            {
                                dispatchMessage(c_Notification, "Fetching " + acontrolConfig.logClass + " logs for product " + acontrolConfig.logProduct, sender);
                            }

                            // Apply functions defined in Control

                            if (acontrolConfig.pathFilter != "")
                            {
                                try
                                {
                                    var pathfilterArray = acontrolConfig.pathFilter.Split('|');

                                    fetchedlogLocation = fetchedlogLocation.ToLower().Replace(pathfilterArray[0], pathfilterArray[1]);
                                }
                                catch (Exception ee)
                                {
                                    diagnosticMessage("  Error handling custom location - " + ee.Message);
                                }
                            }

                            if (fetchedlogLocation.EndsWith(@"\"))
                            {
                                fetchedlogLocation = fetchedlogLocation.Substring(0, fetchedlogLocation.Length - 1);
                            }

                            if (acontrolConfig.pathAppend != "")
                            {
                                fetchedlogLocation = Path.Combine(fetchedlogLocation, acontrolConfig.pathAppend);
                            }

                            if (!logpathHistory.Contains(fetchedlogLocation.ToLower()) || acontrolConfig.disregardduplicatePath)
                            {
                                logpathHistory.Add(fetchedlogLocation.ToLower());

                                var searchOptions = new SearchOption();

                                if (acontrolConfig.recurseDirectory)
                                {
                                    searchOptions = SearchOption.AllDirectories;
                                }
                                else
                                {
                                    searchOptions = SearchOption.TopDirectoryOnly;
                                }

                                //

                                if (fetchedlogLocation != null && fetchedlogLocation != "") // If we have a Directory, proceed
                                {
                                    try
                                    {
                                        // Retrieve the logs                                        

                                        Stopwatch astopWatch = new Stopwatch(); // Stopwatch Starts

                                        astopWatch.Start();

                                        foreach (string fulllogName in Directory.GetFiles(fetchedlogLocation, acontrolConfig.fileMask, searchOptions)) // Swapped EnumerateFiles for GetFiles to reduce possible file locking
                                        {
                                            // Timer Stops

                                            astopWatch.Stop();

                                            FileInfo thelogFile = new System.IO.FileInfo(fulllogName);

                                            var logfileSize = thelogFile.Length;

                                            DateTime loglastModified = thelogFile.LastWriteTime;

                                            string logtypeFilter = "";

                                            if (!fulllogName.EndsWith("_"))
                                            {
                                                logtypeFilter = c_activelog_Extension;
                                            }
                                            else
                                            {
                                                logtypeFilter = c_archivelog_Extension; // This should only apply to CM logs, as they use the .lo_ format for archive logs
                                            }

                                            string cleanedlogName = fulllogName.ToLower().Replace(logtypeFilter.ToLower(), "").Replace(fetchedlogLocation.ToLower() + @"\", "");

                                            cleanedlogName = cleanedlogName.Substring(cleanedlogName.LastIndexOf(@"\") + 1, cleanedlogName.Length - cleanedlogName.LastIndexOf(@"\") - 1);

                                            logItem newlogItem = new logItem();

                                            newlogItem.logDevice = acontrolConfig.remoteServer;
                                            newlogItem.logProduct = acontrolConfig.logProduct;
                                            newlogItem.fulllogName = fulllogName;
                                            newlogItem.logClass = acontrolConfig.logClass;
                                            newlogItem.LogName = cleanedlogName;
                                            newlogItem.logLocation = fetchedlogLocation;

                                            if (logtypeFilter == c_activelog_Extension)
                                            {
                                                newlogItem.logType = c_activeLog;
                                            }
                                            else
                                            {
                                                newlogItem.logType = c_archiveLog;
                                            }

                                            newlogItem.logSize = logfileSize;
                                            newlogItem.loglastModified = loglastModified;

                                            existinglogitemCollection.Add(newlogItem);
                                        }

                                        TimeSpan atimeSpan = TimeSpan.FromMilliseconds(astopWatch.ElapsedMilliseconds);

                                        string stopwatchResult = string.Format("{0:D2}m:{1:D2}s:{2:D3}ms",
                                                                atimeSpan.Minutes,
                                                                atimeSpan.Seconds,
                                                                atimeSpan.Milliseconds);

                                        dispatchMessage(c_Diagnostic, "  " + stopwatchResult + " to scan " + acontrolConfig.logProduct + @"\" + acontrolConfig.logClass, sender);
                                    }
                                    catch (Exception ee)
                                    {
                                        dispatchMessage(c_Diagnostic, "  " + ee.Message, sender);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        dispatchMessage(c_Diagnostic, "  " + ee.Message, sender);
                    }
                }
            }
            catch (Exception ee)
            {
                dispatchMessage(c_Diagnostic, "  " + ee.Message, sender);
            }

            return existinglogitemCollection;
        }


        private logitemCollection logDiscovery(string remoteServer, object sender)
        {
            if (remoteServer == "")
            {
                remoteServer = System.Environment.MachineName.ToUpper();
            }

            BackgroundWorker worker = sender as BackgroundWorker;

            messageObject amessageObject = new messageObject();

            amessageObject.logType = c_Diagnostic;
            amessageObject.logMessage = "Preparing Scan Manifest for " + remoteServer;

            worker.ReportProgress(0, amessageObject);

            logitemCollection alogitemCollection = new logitemCollection();

            // Prepare the collections

            combinedconfigCollection acombinedconfigCollection = new combinedconfigCollection();

            // Site logs            

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = "Site";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\SMS\Identification";
                aregistrybladeConfig.registryvalidationkey = @"Installation Directory";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\SMS\Identification";
                aregistrybladeConfig.registryValue = @"Installation Directory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            // Site setup logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "ConfigMgr*.lo*";
                acontrolConfig.logClass = "Site Setup";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = false;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup";
                aregistrybladeConfig.registryvalidationkey = @"BootDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup";
                aregistrybladeConfig.registryValue = @"BootDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// Agent logs and Management Point

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent-MP";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";
                aregistrybladeConfig.registryvalidationPath = @"Software\Microsoft\CCM\Logging\@Global";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"Software\Microsoft\CCM\Logging\@Global";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            // Check alternative location path

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent-MP";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"software\Microsoft\sms\client\configuration\client properties";
                aregistrybladeConfig.registryvalidationkey = @"Local SMS Path";

                aregistrybladeConfig.registryPath = @"software\Microsoft\sms\client\configuration\client properties";
                aregistrybladeConfig.registryValue = @"Local SMS Path";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// CCMSETUP

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent Setup";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"CCMSETUP\Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// DP logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Distribution Point";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\SMS\DP\Logging\@Global";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\SMS\DP\Logging\@Global";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// Console logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Console";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\AdminUI";
                aregistrybladeConfig.registryvalidationkey = @"AdminUILog";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\AdminUI";
                aregistrybladeConfig.registryValue = @"AdminUILog";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// 1e Nomad

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Nomad";
                acontrolConfig.logProduct = "1e";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"software\1e\NomadBranch";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"software\1e\NomadBranch";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// 1e Tachyon

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Tachyon";
                acontrolConfig.logProduct = "1e";
                acontrolConfig.pathAppend = @"1e\Tachyon";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryvalidationkey = @"Common AppData";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryValue = @"Common AppData";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// IIS

            try
            {
                // First get the path to IIS installation and form the full path to the config file

                Object iisinstallPath = getregkeyValue(remoteServer, "HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\InetStp", "InstallPath");

                string configfilePath = iisinstallPath + @"\Config\applicationHost.config";

                configfilePath = @"\\" + remoteServer + @"\" + configfilePath.Replace(@":", "$");

                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                xmlbladeConfig axmlbladeConfig = new xmlbladeConfig();


                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Web Server";
                acontrolConfig.logProduct = "IIS";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                axmlbladeConfig.configfilePath = configfilePath;
                axmlbladeConfig.searchPattern = "log";
                axmlbladeConfig.searchcaseSensitive = false;
                axmlbladeConfig.searchProperty = "directory=";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = axmlbladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            // 2Pint Software

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"2Pint Stifler";
                acontrolConfig.logProduct = "2Pint";
                acontrolConfig.pathAppend = @"2PintSoftware";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryvalidationkey = @"Common AppData";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryValue = @"Common AppData";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// Adaptiva Onesite

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"OneSite";
                acontrolConfig.logProduct = "Adaptiva";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"Software\Wow6432Node\Adaptiva\client";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"Software\Wow6432Node\Adaptiva\client";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// Windows

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Temp Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Temp";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows System Log";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"System32\LogFiles";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Setup Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Panther";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Sysprep Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"System32\Sysprep\Panther";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Directory";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = false;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            // WSUS Server logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"WSUS Server Logs";
                acontrolConfig.logProduct = "WSUS Server";
                acontrolConfig.pathAppend = @"Update Services\LogFiles";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"ProgramFilesDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
                aregistrybladeConfig.registryValue = @"ProgramFilesDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            //// SQL

            try
            {
                // First get the path to SQL installation paths for each instance of RS and SQL Engine 

                string[] sqlserverInstances = getregkeyValues(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");

                string[] rsserverInstances = getregkeyValues(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\RS");

                foreach (string instanceName in sqlserverInstances)
                {
                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "SQLAGENT*";
                        acontrolConfig.disregardduplicatePath = false;
                        acontrolConfig.logClass = @"SQL Database Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = "log";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLDataRoot";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLDataRoot";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "ERRORLOG*";
                        acontrolConfig.disregardduplicatePath = true;
                        acontrolConfig.logClass = @"SQL Database Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = "log";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLDataRoot";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLDataRoot";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception)
                    {

                    }
                }

                foreach (string instanceName in rsserverInstances)
                {
                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\RS", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "*.lo*";
                        acontrolConfig.logClass = @"SQL Reporting Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = @"LogFiles";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLPath";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLPath";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.disregardduplicatePath = false;
                acontrolConfig.logClass = @"SQL Setup Logs";
                acontrolConfig.logProduct = "SQL Server";
                acontrolConfig.pathAppend = "log";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\120\Bootstrap";
                aregistrybladeConfig.registryvalidationkey = @"BootStrapDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\120\Bootstrap";
                aregistrybladeConfig.registryValue = @"BootStrapDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            // Powershell Application Deployment Toolkit

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.disregardduplicatePath = false;
                acontrolConfig.logClass = @"PADT Logs";
                acontrolConfig.logProduct = "PowerShell Application Deployment Toolkit";
                acontrolConfig.pathAppend = @"Logs\Software";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception)
            {

            }

            amessageObject.logType = c_Diagnostic;
            amessageObject.logMessage = "  Adding custom locations to the scan manifest";

            worker.ReportProgress(0, amessageObject);

            // Retrieve any custom log locations along with their log file suffixes and whether to recurse the directories

            try
            {
                string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                foreach (string customlogLocation in customlogLocations)
                {
                    try
                    {
                        string[] splitElements = customlogLocation.Split('|');

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        custombladeConfig acustombladeConfig = new custombladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = splitElements[1];
                        acontrolConfig.disregardduplicatePath = false;
                        acontrolConfig.logClass = splitElements[4];
                        acontrolConfig.logProduct = splitElements[3];
                        acontrolConfig.pathAppend = @"";
                        acontrolConfig.pathFilter = ":|$";
                        acontrolConfig.recurseDirectory = Convert.ToBoolean(splitElements[2]);

                        acustombladeConfig.logPath = splitElements[0];

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = acustombladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {

            }

            /// The list of logs to be processed have been defined, now run fetchLogs to get the log metadata

            return fetchLogs(acombinedconfigCollection, alogitemCollection, sender);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private List<string> getlogProducts(logitemCollection logCollection, string targetDevice)
        {
            try
            {
                List<string> productNames = new List<string>();

                foreach (logItem alogItem in logCollection)
                {
                    if (alogItem.logDevice == targetDevice)
                    {
                        if (!productNames.Contains(alogItem.logProduct))
                        {
                            productNames.Add(alogItem.logProduct);
                        }
                    }
                }

                return productNames;
            }
            catch (Exception)
            {
                diagnosticMessage("Failure to lookup log products");
            }

            return null;
        }

        private logitemCollection getlogClasses(logitemCollection logCollection, string targetDevice)
        {
            logitemCollection alogitemCollection = new logitemCollection();

            List<string> classNames = new List<string>();

            foreach (logItem alogItem in logCollection)
            {
                if (alogItem.logDevice == targetDevice)
                {
                    if (!classNames.Contains(alogItem.logClass))
                    {
                        classNames.Add(alogItem.logClass);

                        alogitemCollection.Add(alogItem);
                    }
                }
            }

            return alogitemCollection;
        }

        private void buildtreeView(logitemCollection theLogs, string targetDevice)
        {
        // Helper for Site and Client detection

            tv_Logs.Font = new Font(globalfontName, globalfontSize, FontStyle.Regular);

            siteserverDetected = false;

            clientDetected = false;

            List<string> deviceList = new List<string>();

            if (targetDevice != "")
            {
                deviceList.Add(targetDevice);
            }
            else
            {

                foreach (logItem alogItem in theLogs)
                {
                    if (!deviceList.Contains(alogItem.logDevice)) deviceList.Add(alogItem.logDevice);
                }
            }
            
            // tv_Logs.BeginUpdate(); // Set treeview so that we can update it quickly

            disabletreeView = true; // Set so other methods do not interact with the treeview

            if (targetDevice == "")
            {
                tv_Logs.Nodes.Clear();
            }


            foreach (string deviceTarget in deviceList)
            {                
                tv_Logs.Nodes.Add(deviceTarget); // Add the device as a parent node

                TreeNode lastparentNode = tv_Logs.Nodes[tv_Logs.Nodes.Count - 1];

                List<string> productList = getlogProducts(theLogs, deviceTarget);

                try
                {
                    foreach (string productName in productList)
                    {
                        lastparentNode.Nodes.Add(productName);

                        TreeNode childNode = lastparentNode.Nodes[lastparentNode.Nodes.Count - 1];

                        logitemCollection logClasses = getlogClasses(theLogs, deviceTarget);

                        foreach (logItem alogItem in logClasses)
                        {
                            try
                            {
                                if (alogItem.logProduct == productName)
                                {
                                    if (alogItem.logClass == "Site") // Detect if a Site is being added
                                    {
                                        siteserverDetected = true;
                                    }

                                    if (alogItem.logClass == @"Agent-MP") // Detect if a ConfigMgr Agent is being added
                                    {
                                        clientDetected = true;
                                    }

                                    childNode.Nodes.Add(alogItem.logClass);
                                }
                            }
                            catch (Exception ee)
                            {
                                diagnosticMessage("Logic implosion during build of TreeView - " + ee.Message);
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Logic implosion during build of TreeView - " + ee.Message);
                }

            }

            // Find last added Parent node - Change to find the device target

            TreeNode atreeNode = new TreeNode();

            foreach (TreeNode insidatreeNode in tv_Logs.Nodes)
            {
                if (insidatreeNode.Text == targetDevice)
                {
                    insidatreeNode.ExpandAll();
                }
                else
                {
                    insidatreeNode.Collapse();
                }
            }

            //tv_Logs.SelectedNode = tv_Logs.Nodes[tv_Logs.Nodes.Count - 1];

            //tv_Logs.SelectedNode.ExpandAll();

            try
            {
                TreeNode selectedtvNode = tv_Logs.Nodes[0];

                selectedtvNode.BackColor = Color.LightBlue;

                tv_Logs.SelectedNode = selectedtvNode;
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion getting selected TreeView node - " + ee.Message);
            }

            //tv_Logs.EndUpdate();

            disabletreeView = false;
        }

        private void renderLogs(bool ignoretreeView, string targetDevice)
        {            
            dgv_Logs.Rows.Clear(); // Clear DGV rows         

            if (!ignoretreeView) // Build tree view
            {
                buildtreeView(globallogitemCollection, targetDevice);
            }

            string deviceTarget = "";

            if (deviceTarget == "")
            {
                deviceTarget = gettvselectednodedeviceName(); // Get the device that is being referenced in the TreeView
            }
            else
            {
                deviceTarget = targetDevice;
            }

            // Add the row if it meets criteria

            try
            {
                foreach (logItem thelogItem in globallogitemCollection)
                {
                    if (thelogItem.logDevice == deviceTarget) // Focus on the device node family selected in the treeview
                    {
                        if (thelogItem.logType == c_archiveLog && switches_hide_archiveLogs)
                        {

                        }
                        else
                        {
                            if (thelogItem.logClass == this.tv_Logs.SelectedNode.Text || thelogItem.logProduct == this.tv_Logs.SelectedNode.Text || thelogItem.logDevice == this.tv_Logs.SelectedNode.Text)
                            {
                                if (rcc_ignoreCRASHDUMP.Checked && thelogItem.fulllogName.ToLower().Contains("crashdump"))
                                {

                                }
                                else
                                {
                                    dgvAdd(thelogItem.logProduct, thelogItem.fulllogName, thelogItem.logClass, thelogItem.LogName, thelogItem.logLocation, thelogItem.logType, thelogItem.logSize, thelogItem.loglastModified, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            if (rcc_sortbyModified.Checked)
            {
                highlightandmovetodgvRow(dgv_Logs, false, "dgv_c_lastWritten", true);

                dgv_Logs.ClearSelection();
            }            
        }

        private void updateGradient()
        {
            colourList.Clear();

            colourList.Add(rcc_Newest.Color); // Add the starting Color

            // Attribution to Steinwolfe on Stackoverflow for the below Color gradient code

            double aStep = (rcc_Oldest.Color.A - rcc_Newest.Color.A) / 20;
            double rStep = (rcc_Oldest.Color.R - rcc_Newest.Color.R) / 20;
            double gStep = (rcc_Oldest.Color.G - rcc_Newest.Color.G) / 20;
            double bStep = (rcc_Oldest.Color.B - rcc_Newest.Color.B) / 20;

            for (int i = 1; i < 20; i++)
            {
                var a = rcc_Newest.Color.A + (int)(aStep * i);
                var r = rcc_Newest.Color.R + (int)(rStep * i);
                var g = rcc_Newest.Color.G + (int)(gStep * i);
                var b = rcc_Newest.Color.B + (int)(bStep * i);

                colourList.Add(Color.FromArgb(a, r, g, b));

                // Attribution to Steinwolfe on Stackoverflow for the above colour gradient code
            }

            colourList.Add(rcc_Oldest.Color); // Add the ending colour
        }

        private void checkforconsoleIntegration()
        {
            // Check for the Console, if it exists and we're not integrated yet, prompt to perform the integration

            diagnosticMessage("Checking for ConfigMgr Console ...");

            try
            {
                if (regkeyvalueExist("", "HKEY_LOCAL_MACHINE", @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\Setup", "UI Installation Directory"))
                {
                    diagnosticMessage("  ConfigMgr Console found.");

                    string cmconsolePath = getregkeyValue("", "HKEY_LOCAL_MACHINE", @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\Setup", "UI Installation Directory").ToString();

                    string loglauncherPath = System.IO.Directory.GetCurrentDirectory() + @"\LogLauncher.exe";

                    if ((!File.Exists(cmconsolePath + @"xmlstorage\extensions\actions\3fd01cd1-9e01-461e-92cd-94866b8d1f39\LogLauncher.xml")) || (!File.Exists(cmconsolePath + @"xmlstorage\extensions\actions\ed9dee86-eadd-4ac8-82a1-7234a4646e62\LogLauncher.xml")))
                    {
                        // Prompt to integrate with the CM Console

                        DialogResult dialogResult = MessageBox.Show("Do you want to integrate LogLauncher with the ConfigMgr Console?", "ConfigMgr Console detected", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            diagnosticMessage("  Commencing with Console integration ...");

                            // Create Action folders if they do not already exist

                            string[] logLauncherXML = new[] { "<ActionDescription Class=" + (char)34 + "Executable" + (char)34 + " DisplayName=" + (char)34 + "Log Launcher" + (char)34 + " MnemonicDisplayName=" + (char)34 + "Log Launcher" + (char)34 + " Description=" + (char)34 + "Launchers Log Launcher" + (char)34 + " RibbonDisplayType=" + (char)34 + "TextAndSmallImage" + (char)34 + "><ShowOn><string>ContextMenu</string><string>DefaultHomeTab</string></ShowOn><Executable><FilePath>" + (char)34 + loglauncherPath + (char)34 + "</FilePath><Parameters> " + (char)34 + "##SUB:Name##" + (char)34 + "</Parameters></Executable></ActionDescription>" };

                            if (!Directory.Exists(cmconsolePath + @"xmlstorage\extensions\actions\3fd01cd1-9e01-461e-92cd-94866b8d1f39"))
                            {
                                Directory.CreateDirectory(cmconsolePath + @"xmlstorage\extensions\actions\3fd01cd1-9e01-461e-92cd-94866b8d1f39");
                            }

                            if (!Directory.Exists(cmconsolePath + @"xmlstorage\extensions\actions\ed9dee86-eadd-4ac8-82a1-7234a4646e62"))
                            {
                                Directory.CreateDirectory(cmconsolePath + @"xmlstorage\extensions\actions\ed9dee86-eadd-4ac8-82a1-7234a4646e62");
                            }

                            // Create the XML files if they do not already exist

                            if (!File.Exists(cmconsolePath + @"xmlstorage\extensions\actions\3fd01cd1-9e01-461e-92cd-94866b8d1f39\LogLauncher.xml"))
                            {
                                System.IO.File.WriteAllLines(cmconsolePath + @"xmlstorage\extensions\actions\3fd01cd1-9e01-461e-92cd-94866b8d1f39\LogLauncher.xml", logLauncherXML);
                            }

                            if (!File.Exists(cmconsolePath + @"xmlstorage\extensions\actions\ed9dee86-eadd-4ac8-82a1-7234a4646e62\LogLauncher.xml"))
                            {
                                System.IO.File.WriteAllLines(cmconsolePath + @"xmlstorage\extensions\actions\ed9dee86-eadd-4ac8-82a1-7234a4646e62\LogLauncher.xml", logLauncherXML);
                            }

                            MessageBox.Show("Integrated, restart the ConfigMgr Console for changes to take effect", "ConfigMgr Console Integrated");
                        }
                    }
                }
            }
            catch (Exception)
            {
                diagnosticMessage("Failed to handle integration with ConfigMgr Console");
            }
        }

        private Bitmap loadimagefromString(string Image)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Image);

                MemoryStream ms = new MemoryStream(imageBytes);

                Bitmap streamImage = (Bitmap)Bitmap.FromStream(ms, true);

                return streamImage;
            }
            catch (Exception)
            {

            }

            return null;
        }

        private void getsupportCenter()
        {
            try
            {
                if (regkeyExist(System.Environment.MachineName.ToUpper(), "HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\Folders"))
                {
                    foreach (string folderName in getregkeyValues(System.Environment.MachineName.ToUpper(), "HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\Folders"))
                    {
                        if (folderName.Contains("Configuration Manager Support Center"))
                        {
                            supportcenterPath = folderName + @"\ConfigMgrSupportCenter.exe";

                            rb_supportCenter.Visible = true;
                        }
                    }
                }

                if (supportcenterPath == "" || supportcenterPath == null)
                {
                    rb_supportCenter.Visible = false;
                }
            }
            catch (Exception)
            {
                diagnosticMessage("Error while looking up Configuration Manager Client Center");
            }
        }

        private void populatelogHints()
        {
            notificationMessage("Building ConfigMgr Log Hints ...", this.BackColor);            

            for (int i = 0; i < logHints.GetLength(0); i++)
            {
                try
                {
                    logdescriptionItem alogdescriptionItem = new logdescriptionItem();

                    alogdescriptionItem.LogFilename = logHints[i, 0];
                    alogdescriptionItem.LogMessage1 = logHints[i, 1];

                    globallogdescriptionItemCollection.Add(alogdescriptionItem);
                }
                catch (Exception)
                {

                }
            }

            notificationMessage("Done building ConfigMgr Log Hints.", this.BackColor);
        }

        private void processTracer()
        {
            if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "TracerPath"))
            {
                TracerPath = getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "TracerPath").ToString();

                if (!regkeyvalueExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher", "TracerPath")) // In case HKCU exists and HKLM doesn't
                {
                    updateloglauncherSettings(returnregistryHive("HKEY_LOCAL_MACHINE"), "TracerPath", TracerPath);

                    diagnosticMessage("Fallback Tracer has been recorded to HKLM");
                }
            }
            else
            {
                if (regkeyvalueExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher", "TracerPath"))
                {
                    TracerPath = getregkeyValue("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher", "TracerPath").ToString();

                    DialogResult adialogResult = MessageBox.Show("A default tracer has been found, '" + TracerPath + "' do you wish to use it?", "No tracer specified", MessageBoxButtons.YesNo);

                    if (adialogResult == DialogResult.No)
                    {
                        openFileDialog1.InitialDirectory = Environment.SystemDirectory;
                        openFileDialog1.Filter = "Tracer (*.exe)|*.exe";
                        openFileDialog1.FileName = "";

                        DialogResult result = openFileDialog1.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            diagnosticMessage(" Located manually, storing path in preferences");

                            TracerPath = openFileDialog1.FileName;
                        }
                        else
                        {
                            diagnosticMessage("No Tracer found, using Notepad instead ...");

                            TracerPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)) + @"\Notepad.exe";
                        }                                     
                    }

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "TracerPath", TracerPath);
                }
                else
                {
                    // Let user know we're about to select the Tracer

                    DialogResult adialogResult = MessageBox.Show("Welcome, before you begin I need you to select your preferred Tracing tool, to begin select OK and navigate to the tool", "Select a Tracing tool", MessageBoxButtons.OK);

                    // prompt for tracer path

                    openFileDialog1.InitialDirectory = Environment.SystemDirectory;
                    openFileDialog1.Filter = "Tracer (*.exe)|*.exe";
                    openFileDialog1.FileName = "";

                    DialogResult result = openFileDialog1.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        diagnosticMessage(" Located manually, storing path in preferences");

                        TracerPath = openFileDialog1.FileName;
                    }
                    else
                    {
                        diagnosticMessage("No Tracer found, using Notepad instead ...");

                        TracerPath = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)) + @"\Notepad.exe";
                    }

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "TracerPath", TracerPath);
                    updateloglauncherSettings(returnregistryHive("HKEY_LOCAL_MACHINE"), "TracerPath", TracerPath);
                }
            }

            diagnosticMessage("Tracer found " + TracerPath);

            rtb_tracerPath.TextBoxText = TracerPath;
            rtb_tracerPath.Value = TracerPath;
            rtb_tracerPath.Text = "Tracer";
        }

        private void showhelpText(string filePath)
        {
            byte[] document = File.ReadAllBytes(filePath);
            string base64string = Convert.ToBase64String(document);
            MessageBox.Show(base64string);
        }

        private void checkforRDP()
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                visualEffects = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            // Uncomment to generate Base64 for an RTF file for the Help Panels contents

            // showhelpText(@"c:\TEMP\Help-Form-Contents-Compressed-V3.6.rtf");

            this.Text = c_productTitle; // Set the application Title text

            checkforRDP(); // Check if we are running in Terminal Services (RDP)

            populatelogHints(); // Populate SCCM Log hints

            // Populate Help RichTextBox

            try
            {
                byte[] decodedString = System.Convert.FromBase64String(helpformContent);

                rtb_Help.Rtf = System.Text.Encoding.UTF8.GetString(decodedString);
            }
            catch (Exception ee)
            {
            
            }
            // Populate the Font drop down box on the Ribbon (Configuration)

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                RibbonTextBox aribbontextBox = new RibbonTextBox();

                aribbontextBox.TextBoxText = font.Name;
                aribbontextBox.Value = font.Name;
                aribbontextBox.Text = font.Name;

                aribbontextBox.AllowTextEdit = false;

                rcb_Fonts.DropDownItems.Add(aribbontextBox);

                rcb_Fonts.SelectedItem = aribbontextBox;                
            }

            // Set dgv_Logs Font

            dgv_Logs.ColumnHeadersDefaultCellStyle.Font = new Font(globalfontName, globalfontSize, FontStyle.Regular);

            // Set startup phase switch so that methods that detect this switch hold off

            switches_startupPhase = true; 

            // Convert images stored as Base64 into Bitmaps

            Bitmap imageScan = new Bitmap(loadimagefromString(imagetextScan));
            Bitmap imageMonitor = new Bitmap(loadimagefromString(imagetextMonitor));
            Bitmap imageOpenLogs = new Bitmap(loadimagefromString(imagetextOpenLogs));
            Bitmap imageLocations = new Bitmap(loadimagefromString(imagetextLocations));
            Bitmap imageLogging = new Bitmap(loadimagefromString(imagetextLogging));
            Bitmap imageRefreshLogs = new Bitmap(loadimagefromString(imagetextRefreshLogs));
            Bitmap imageHelp = new Bitmap(loadimagefromString(imagetextHelp));
            Bitmap imageDebugWindow = new Bitmap(loadimagefromString(imagetextDebugWindow));
            Bitmap imageshowLogs = new Bitmap(loadimagefromString(imagetextshowLogs));
            Bitmap imagesupportcenter = new Bitmap(loadimagefromString(imagesupportCenter));
            Bitmap imagefindTracer = new Bitmap(loadimagefromString(imagesfindTracer));
            Bitmap imagepinDown = new Bitmap(loadimagefromString(imagespinDown));
            Bitmap imageZip = new Bitmap(loadimagefromString(imagesZip));

            // Set the Ribbon icons to the newly created Bitmaps

            try
            {
                pb_pinSlider.Image = imagepinDown;

                rb_scanLogs.Image = imageScan;
                rb_Monitor.Image = imageMonitor;
                rb_Monitor.ToolTip = "Start monitoring device Logs";
                rb_openLogs.Image = imageOpenLogs;
                rb_customPaths.Image = imageLocations;
                rb_Help.Image = imageHelp;
                rb_Logging.Image = imageLogging;
                rb_refreshLogs.Image = imageRefreshLogs;
                
                rb_debugWindow.Image = imageDebugWindow;
                rb_showLogs.Image = imageshowLogs;
                rb_supportCenter.Image = imagesupportcenter;
                rb_tracerFind.Image = imagefindTracer;
                rb_zipoutputdirectorySelect.Image = imagefindTracer;

                rb_zipLogs.Image = imageZip;
            }
            catch (Exception)
            {

            }

            // Set Archive File to disabled by default, and make the Active Log column invisible

            try
            {
                switches_hide_archiveLogs = true;

                dgv_Logs.Columns["dgv_c_Type"].Visible = false;
            }
            catch (Exception)
            {

            }

            // Configure the Panels visibility

            panel_Logs.Visible = true;
            panel_Logging.Visible = false;
            panel_customLocations.Visible = false;
            panel_Help.Visible = false;
            panel_Diagnostics.Visible = false;

            checkforconsoleIntegration(); // Check for ConfigMgr Console integration

            getloglauncherSettings(); // Get Log Launcher settings from HKCU Registry hive

            ribbon1.Font = new Font(globalfontName, 8, FontStyle.Regular);

            updateGradient(); // Create the colour gradient palette for log monitoring

            throttleDelay = Convert.ToInt16(rup_Duration.Value); // Set throttle value

            dgv_Logs.ContextMenuStrip = contextMenuStrip1; // Add context menu strip

            toolStripStatusLabel2.Text = c_productVersion + " by Robert Marshall EM MVP"; // Set version in status strip

            processTracer(); // Handle Tracer

            getsupportCenter(); // Locate ConfigMgr Support Center

            populateserverMRU(); // Populate the Server MRU list for the deviceName combobox

            // Get Command line parameter for device to connect too, if it isn't supplied then it remains empty            

            getcommandlineParameters(); // Placed here so that it overrides all other changes if command line is supplied

            // Check if the override for device name is specified, if it is refer too it for the initial scan, otherwise set to local device

            string targetDevice = "";

            if (cmdlinedeviceName != "")
            {
                targetDevice = cmdlinedeviceName.ToUpper();
            }
            else
            {
                targetDevice = System.Environment.MachineName.ToUpper();
            }

            // Perform log discovery

            notificationMessage("Discovering Logs ...", this.BackColor);

            diagnosticMessage("Discovering Logs ...");

            // Prepare the log discovery (scan) thread

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_scan_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_scan_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_scan_RunWorkerCompleted);

            // Locate targetDevice in the ribbons remoteServer drop down box, select it if a matched is found

            foreach (RibbonTextBox aRibbonTextBox in rcb_remoteServer.DropDownItems)
            {
                if (aRibbonTextBox.Text.ToUpper() == targetDevice)
                {
                    rcb_remoteServer.SelectedItem = aRibbonTextBox;

                    break; // Found a match so leave the loop
                }
            }

            // Start the log discovery (scan) thread

            reportSuffixUpdatedRows outgoingcommBlock = new reportSuffixUpdatedRows();

            outgoingcommBlock.additionalText = targetDevice;

            bw.RunWorkerAsync(outgoingcommBlock);
        }

        private void launchLogs(DataGridViewSelectedRowCollection dgvRows)
        {
            try
            {
                List<string> logList = new List<string>();

                foreach (DataGridViewRow dgvRow in dgvRows)
                {
                    string logName = dgvRow.Cells["dgv_c_hiddenlogName"].Value.ToString();

                    logList.Add((char)34 + logName + (char)34);
                }

                if (!switches_open_multipleLogs)
                {
                    foreach (string logtoOpen in logList)
                    {
                        ProcessStartInfo newProcess = new ProcessStartInfo();

                        newProcess.FileName = TracerPath;

                        newProcess.Arguments = logtoOpen;

                        newProcess.CreateNoWindow = false;

                        newProcess.UseShellExecute = false;

                        try
                        {
                            Process.Start(newProcess);
                        }
                        catch (Exception ee)
                        {
                            notificationMessage("Could not start Tracer " + ee.Message, this.BackColor);
                        }
                    }
                }

                if (switches_open_multipleLogs)
                {
                    // TracerPath

                    ProcessStartInfo newProcess = new ProcessStartInfo();

                    newProcess.FileName = TracerPath;

                    newProcess.Arguments = string.Join(" ", logList.ToArray());

                    newProcess.CreateNoWindow = false;

                    newProcess.UseShellExecute = false;

                    try
                    {
                        Process.Start(newProcess);
                    }
                    catch (Exception ee)
                    {
                        notificationMessage("Could not start Tracer " + ee.Message, this.BackColor);
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Failure launching logs - " + ee.Message);
            }
        }

        private void dgv_Logs_DoubleClick(object sender, EventArgs e)
        {
            launchLogs(dgv_Logs.SelectedRows);
        }

        private void tv_Logs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!afterselectDisabled)
            {
                panel_customLocations.Visible = false;
                panel_Logs.Visible = true;
                panel_Logging.Visible = false;
                panel_Help.Visible = false;
                panel_Diagnostics.Visible = false;

                // Change the colour of the currently selected node

                try
                {
                    foreach (TreeNode tvNode in this.tv_Logs.Nodes)
                    {
                        foreach (TreeNode tvnodeCategory in tvNode.Nodes)
                        {
                            foreach (TreeNode tvnodeProduct in tvnodeCategory.Nodes)
                            {
                                if (tvnodeProduct == this.tv_Logs.SelectedNode)
                                {
                                    tvnodeProduct.BackColor = Color.LightBlue;
                                }
                                else
                                {
                                    tvnodeProduct.BackColor = tv_Logs.BackColor;
                                }
                            }

                            if (tvnodeCategory == this.tv_Logs.SelectedNode)
                            {
                                tvnodeCategory.BackColor = Color.LightBlue;
                            }
                            else
                            {
                                tvnodeCategory.BackColor = tv_Logs.BackColor;
                            }
                        }

                        if (tvNode == this.tv_Logs.SelectedNode)
                        {
                            tvNode.BackColor = Color.LightBlue;
                        }
                        else
                        {
                            tvNode.BackColor = tv_Logs.BackColor;
                        }
                    }
                }
                catch (Exception)
                {

                }

                try
                {
                    if (!disabletreeView)
                    {
                        renderLogs(true, "");
                    }

                    notificationMessage(this.tv_Logs.SelectedNode.FullPath + " contains " + dgv_Logs.Rows.Count.ToString() + " objects - " + getSaying(), this.BackColor);
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Error during tv_Logs_afterSelect - " + ee.Message);
                }

                // If enabled refresh the data in the selected Node so the user is always looking at current information

                if (rcb_refreshnodesonClick.Checked) // Is Auto Refresh Logs turned on
                {
                    if (!monitortargetList.Contains(tv_Logs.SelectedNode.FullPath)) // Check if selected node is being monitored, if it is skip refreshing its data
                    {
                        logitemCollection tosendlogitemCollection = convertdgvtologItems(dgv_Logs.Rows);

                        tosendlogitemCollection = refreshlogsinDataset(tosendlogitemCollection);

                        updatedgvRows(tosendlogitemCollection, true); // Render the updated logitem Collection                    
                    }
                }
            }
        }

        private void populateclientPanel(string remoteServer)
        {
            try
            {
                int logEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogEnabled");
                int logLevel = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogLevel");
                int logmaxHistory = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogMaxHistory");
                int logmaxSize = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogMaxSize");

                if (Convert.ToInt16(logEnabled) != 0)
                {
                    cb_client_Logging.Checked = true;
                }
                else
                {
                    cb_client_Logging.Checked = false;
                }

                nud_client_logLevel.Value = logLevel;
                nud_client_logmaxHistory.Value = logmaxHistory;
                nud_client_logmaxSize.Value = logmaxSize;

                if (regkeyExist(remoteServer, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                {
                    cb_client_debugLogging.Checked = true;
                }
                else
                {
                    cb_client_debugLogging.Checked = false;
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error while obtaining client logging properties - " + ee.Message);
            }
        }

        private void populateserverPanel(string remoteServer)
        {
            try
            {
                int logEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "Enabled");
                int sqlLogging = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "SqlEnabled");
                int archiveEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "ArchiveEnabled");

                if (logEnabled != 0)
                {
                    cb_site_siteLogging.Checked = true;
                }
                else
                {
                    cb_site_siteLogging.Checked = false;
                }

                if (sqlLogging != 0)
                {
                    cb_site_sqlLogging.Checked = true;
                }
                else
                {
                    cb_site_sqlLogging.Checked = false;
                }

                if (archiveEnabled != 0)
                {
                    cb_site_archiveLogs.Checked = true;
                }
                else
                {
                    cb_site_archiveLogs.Checked = false;
                }

                int providerlogLevel = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "Logging Level");
                int providersqlCache = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "SQL Cache Logging Level");
                int providerlogSize = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "Log Size Mb");

                num_provider_loggingLevel.Value = providerlogLevel;
                num_provider_sqlcacheloggingLevel.Value = providersqlCache;
                num_provider_logsizeMb.Value = providerlogSize;
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error while obtaining server logging properties - " + ee.Message);
            }
        }

        private void storedevicenameMRU(string logDevice)
        {
            RibbonTextBox aribbontextBox = new RibbonTextBox();

            aribbontextBox.TextBoxText = logDevice.ToUpper();
            aribbontextBox.Text = logDevice.ToUpper();
            aribbontextBox.Value = logDevice.ToUpper();

            aribbontextBox.AllowTextEdit = false;

            bool entrywasFound = false;

            try
            {
                foreach (RibbonTextBox aRibbonTextBox in rcb_remoteServer.DropDownItems)
                {
                    if (aRibbonTextBox.TextBoxText.ToUpper() == rcb_remoteServer.TextBoxText.ToUpper())
                    {
                        entrywasFound = true;

                        break;
                    }
                }
            }
            catch (Exception)
            {

            }

            if (!entrywasFound && logDevice != "")
            {
                try
                {
                    if (rcb_remoteServer.DropDownItems.Count > 9)
                    {
                        rcb_remoteServer.DropDownItems.RemoveAt(0);
                    }

                    rcb_remoteServer.DropDownItems.Add(aribbontextBox);

                    rcb_remoteServer.SelectedItem = aribbontextBox;

                    // Store recent servers back to registry

                    string[] recentserverArray = new string[rcb_remoteServer.DropDownItems.Count];

                    int i = 0;

                    foreach (RibbonItem aribbonItem in rcb_remoteServer.DropDownItems)
                    {
                        recentserverArray[i] = aribbonItem.Text;

                        i++;
                    }

                    setregkeyValues("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers", recentserverArray);
                }
                catch (Exception)
                {

                }
            }
        }

        private string getSaying()
        {
            try
            {
                var spacedistortionField = new Random((int)DateTime.Now.Ticks);

                var distortedfieldInteger = spacedistortionField.Next(0, c_Sayings.Count);

                return c_Sayings[distortedfieldInteger];
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error producing a saying" + ee.Message);
            }

            return "";
        }

        private void bw_logging_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string remoteServer = (string)e.Argument;

            switches_logging_threadRunning = true;

            loggingitemCollection aloggingitemCollection = new loggingitemCollection();

            try
            {
                RegistryKey componentKeys = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), remoteServer);

                componentKeys = componentKeys.OpenSubKey(@"SOFTWARE\Microsoft\SMS\Tracing");

                foreach (string asubkeyName in componentKeys.GetSubKeyNames())
                {
                    loggingItem aloggingItem = new loggingItem();

                    aloggingItem.componentName = asubkeyName;

                    RegistryKey componentKey = componentKeys.OpenSubKey(asubkeyName, true);

                    if (componentKey != null)
                    {
                        foreach (string valueName in componentKey.GetValueNames())
                        {
                            if (valueName == "DebugLogging")
                            {
                                if (componentKey.GetValue(valueName).ToString() != "")
                                {
                                    try
                                    {
                                        aloggingItem.debugLogging = Convert.ToBoolean(componentKey.GetValue(valueName).ToString());
                                    }
                                    catch (Exception)
                                    {
                                        aloggingItem.debugLogging = false;
                                    }
                                }
                            }

                            if (valueName == "Enabled")
                            {
                                if (componentKey.GetValue(valueName).ToString() != "")
                                {
                                    try
                                    {
                                        object enabledState = componentKey.GetValue(valueName);

                                        aloggingItem.Enabled = Convert.ToBoolean(enabledState);
                                    }
                                    catch (Exception)
                                    {
                                        aloggingItem.Enabled = false;
                                    }
                                }
                            }

                            if (valueName == "LoggingLevel")
                            {
                                if (componentKey.GetValue(valueName).ToString() != "")
                                {
                                    try
                                    {
                                        aloggingItem.loggingLevel = (int)componentKey.GetValue(valueName);
                                    }
                                    catch (Exception)
                                    {
                                        aloggingItem.loggingLevel = 0;
                                    }
                                }
                            }

                            if (valueName == "LogMaxHistory")
                            {
                                if (componentKey.GetValue(valueName).ToString() != "")
                                {
                                    try
                                    {
                                        aloggingItem.logmaxHistory = (int)componentKey.GetValue(valueName);
                                    }
                                    catch (Exception)
                                    {
                                        aloggingItem.logmaxHistory = 0;
                                    }
                                }
                            }

                            if (valueName == "MaxFileSize")
                            {
                                if (componentKey.GetValue(valueName).ToString() != "")
                                {
                                    try
                                    {
                                        aloggingItem.maxfileSize = (int)componentKey.GetValue(valueName);
                                    }
                                    catch (Exception)
                                    {
                                        aloggingItem.maxfileSize = 0;
                                    }
                                }
                            }
                        }

                        try
                        {

                        }
                        catch (Exception)
                        {

                        }
                    }

                    aloggingitemCollection.Add(aloggingItem);
                }

                e.Result = aloggingitemCollection;
            }
            catch (Exception)
            {

            }
        }

        private void bw_logging_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                try
                {
                    loggingitemCollection aloggingitemCollection = (loggingitemCollection)e.Result;

                    foreach (loggingItem aloggingItem in aloggingitemCollection)
                    {
                        dgv_Logging.Rows.Add(aloggingItem.componentName, aloggingItem.debugLogging, aloggingItem.Enabled, aloggingItem.loggingLevel, aloggingItem.logmaxHistory, aloggingItem.maxfileSize);
                    }

                    highlightandmovetodgvRow(this.dgv_Logging, false, "c_dgv_logging_componentName", true);

                    dgv_Logs.ClearSelection();
                }
                catch (Exception)
                {

                }

                diagnosticMessage("Retrieved Site Server Logging data");
            }
        }

        private void bw_logging_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            diagnosticMessage(e.UserState.ToString());
        }

        private void bw_serviceCycle_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            servicecycleMessage aservicecycleMessage = (servicecycleMessage)e.Argument;

            try
            {
                ServiceController sc = new ServiceController(aservicecycleMessage.serviceName, aservicecycleMessage.remoteServer);

                try
                {
                    loggingMessage aloggingMessage = new loggingMessage();

                    aloggingMessage.messageType = "Both";
                    aloggingMessage.messageText = "Stopping " + aservicecycleMessage.serviceName + " - This can take a while";

                    worker.ReportProgress(0, aloggingMessage);

                    sc.Stop();

                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception ee)
                {
                    loggingMessage aloggingMessage = new loggingMessage();

                    aloggingMessage.messageType = "Diagnostic";
                    aloggingMessage.messageText = "Error when stopping " + aservicecycleMessage.serviceName + " - " + ee.Message;

                    worker.ReportProgress(0, aloggingMessage);
                }

                if (sc.Status.ToString() == "Stopped")
                {
                    try
                    {
                        loggingMessage aloggingMessage = new loggingMessage();

                        aloggingMessage.messageType = "Both";
                        aloggingMessage.messageText = "Starting " + aservicecycleMessage.serviceName + " - This can take a while";

                        worker.ReportProgress(0, aloggingMessage);

                        sc.Start();

                        aloggingMessage.messageText = aservicecycleMessage.serviceName + " started";

                        worker.ReportProgress(0, aloggingMessage);
                    }
                    catch (Exception ee)
                    {
                        loggingMessage aloggingMessage = new loggingMessage();

                        aloggingMessage.messageType = "Diagnostic";
                        aloggingMessage.messageText = "Error starting " + aservicecycleMessage.serviceName + " - " + ee.Message;

                        worker.ReportProgress(0, aloggingMessage);
                    }
                }
            }
            catch (Exception)
            {
                loggingMessage aloggingMessage = new loggingMessage();

                aloggingMessage.messageType = "Both";
                aloggingMessage.messageText = "Failed handling " + aservicecycleMessage.serviceName;

                worker.ReportProgress(0, aloggingMessage);
            }

            e.Result = aservicecycleMessage.serviceName;
        }

        private void bw_serviceCycle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
            }

            string serviceName = (string)e.Result;

            if (serviceName == "SMS_EXECUTIVE")
            {
                b_cycleSMSEXEC.Enabled = true;
            }
            else
            {
                b_cycleCCMEXEC.Enabled = true;
            }
        }

        private void bw_serviceCycle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loggingMessage aloggingMessage = (loggingMessage)e.UserState;

            if (aloggingMessage.messageType == "Diagnostic" || aloggingMessage.messageType == "Both")
            {
                diagnosticMessage(aloggingMessage.messageText);
            }

            if (aloggingMessage.messageType == "Notification" || aloggingMessage.messageType == "Both")
            {
                notificationMessage(aloggingMessage.messageText, this.BackColor);
            }
        }

        private void bw_slider_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            switches_slider_threadRunning = true;
            switches_Slider = true;

            for (int i = Convert.ToInt16(e.Argument); i > 0; i -= 2)
            {
                worker.ReportProgress(0, i);

                Thread.Sleep(6);

                if (!switches_Slider) break; // Stop the thread
            }
        }


        private void bw_slider_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            splitContainer1.SplitterDistance = Convert.ToInt16(e.UserState);
        }

        private void bw_slider_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                pb_snapOut.Visible = true;
                tv_Logs.Visible = false;
            }

            splitContainer1.ResumeLayout();
        }

        private void bw_scan_DoWork(object sender, DoWorkEventArgs e)
        {
            reportSuffixUpdatedRows incommingcommBlock = (reportSuffixUpdatedRows)e.Argument;

            string deviceName = incommingcommBlock.additionalText;

            switches_scan_threadRunning = true;

            try
            {
                logitemCollection theLogs = logDiscovery(deviceName, sender); // Discover logs

                reportSuffixUpdatedRows outgoingcommBlock = new reportSuffixUpdatedRows();

                outgoingcommBlock.updatedRows = theLogs;
                outgoingcommBlock.additionalText = deviceName;

                e.Result = outgoingcommBlock; // Send to RunWorkerCompleted the device name and log collection
            }
            catch (Exception)
            {

            }
        }

        private void bw_scan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // Store this device in the device MRU

                reportSuffixUpdatedRows incommingcommBlock = (reportSuffixUpdatedRows)e.Result;

                string targetDevice = incommingcommBlock.additionalText;

                storedevicenameMRU(targetDevice);

                diagnosticMessage("Device scanned: " + targetDevice);

                if (e.Cancelled == false)
                {
                    logitemCollection thelogitemCollection = incommingcommBlock.updatedRows;

                    foreach (logItem alogItem in thelogitemCollection) // Add the log scan results to the global logs collection
                    {
                        globallogitemCollection.Add(alogItem);
                    }

                    renderLogs(false, targetDevice);

                    notificationMessage(thelogitemCollection.Count.ToString() + " logs added, total logs " + globallogitemCollection.Count.ToString() + " - " + getSaying(), Color.LightBlue);

                    diagnosticMessage(thelogitemCollection.Count.ToString() + " logs added, total logs " + globallogitemCollection.Count.ToString() + " - " + getSaying());
                }

                if (siteserverDetected) // Populate dgv_Logging
                {
                    loggingpanelDevice aloggingpanelDevice = new loggingpanelDevice();

                    aloggingpanelDevice.deviceName = targetDevice;
                    aloggingpanelDevice.loggingType = "Server";

                    if (!globalloggingpaneldevicesCollection.Contains(aloggingpanelDevice))
                    {
                        globalloggingpaneldevicesCollection.Add(aloggingpanelDevice); // Add 
                    }
                }

                if (clientDetected)
                {
                    // Populate the elements on the p_Client panel

                    loggingpanelDevice aloggingpanelDevice = new loggingpanelDevice();

                    aloggingpanelDevice.deviceName = targetDevice;
                    aloggingpanelDevice.loggingType = "Client";

                    if (!globalloggingpaneldevicesCollection.Contains(aloggingpanelDevice))
                    {
                        globalloggingpaneldevicesCollection.Add(aloggingpanelDevice); // Add 
                    }
                }

                switches_scan_threadRunning = false;

                switches_startupPhase = false;

                rb_scanLogs.Enabled = true;

                highlightandmovetodgvRow(dgv_Logs, false, "dgv_c_lastWritten", true);

                dgv_Logs.ClearSelection();
            }
            catch (Exception ee)
            {
                diagnosticMessage(ee.Message);
            }
        }

        private void bw_scan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            messageObject amessageObject = (messageObject)e.UserState;

            if (amessageObject.logType == c_Notification)
            {
                notificationMessage(amessageObject.logMessage, this.BackColor);
            }

            if (amessageObject.logType == c_Diagnostic)
            {
                diagnosticMessage(amessageObject.logMessage);
            }
        }

        public void ziplogsSaveProgress(object sender,  SaveProgressEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<Object, SaveProgressEventArgs>(ziplogsSaveProgress), new Object[] { sender, e });
                }
                else
                {
                    try
                    {
                        if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
                        {
                            tspb_zipfileCount.Maximum = e.EntriesTotal;

                            tspb_zipfileCount.Value = e.EntriesSaved;
                        }
                        else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
                        {
                            tspb_zipfileProgress.Maximum = 100;

                            tspb_zipfileProgress.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void bw_zipLogs_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                filenamecollectioncombinedConfig afilenamecollectioncombinedConfig = (filenamecollectioncombinedConfig)e.Argument;

                using (ZipFile zipFile = new ZipFile())
                {
                    foreach (logItem alogItem in afilenamecollectioncombinedConfig.alogitemCollection)
                    {
                        ZipEntry zipEntry = zipFile.AddFile(alogItem.fulllogName);
                        zipEntry.Comment = "LogLauncher zip item";
                    }

                    zipFile.Comment = "Created by LogLauncher 3.5";

                    zipFile.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;

                    zipFile.SaveProgress += ziplogsSaveProgress;

                    zipFile.Save(afilenamecollectioncombinedConfig.fileName);

                    e.Result = afilenamecollectioncombinedConfig.fileName;
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void bw_zipLogs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            diagnosticMessage(e.UserState.ToString());
        }

        private void bw_zipLogs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == false)
                {
                    notificationMessage("Completed zip of " + e.Result.ToString(), this.BackColor);
                    diagnosticMessage("Completed zip of " + e.Result.ToString());
                }
                else
                {
                    notificationMessage("Aborted zip.", this.BackColor);
                    diagnosticMessage("Aborted zip.");
                }
            }
            catch (Exception ee)
            {

            }

            tspb_zipfileCount.Visible = false;
            tspb_zipfileProgress.Visible = false;

            zipthreadRunning = false;
        }  

        private void bw_connectdevice_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!regkeyExist(e.Argument.ToString(), "HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Setup"))
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ee)
            {
                e.Cancel = true;
            }

            e.Result = e.Argument;
        }

        private void bw_connectdevice_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_connectdevice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == false)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerSupportsCancellation = true;
                    bw.WorkerReportsProgress = true;
                    bw.DoWork +=
                        new DoWorkEventHandler(bw_scan_DoWork);
                    bw.ProgressChanged +=
                        new ProgressChangedEventHandler(bw_scan_ProgressChanged);
                    bw.RunWorkerCompleted +=
                        new RunWorkerCompletedEventHandler(bw_scan_RunWorkerCompleted);

                    reportSuffixUpdatedRows outgoingcommBlock = new reportSuffixUpdatedRows();                    

                    outgoingcommBlock.additionalText = e.Result.ToString();

                    bw.RunWorkerAsync(outgoingcommBlock);
                }
                else
                {
                    rb_scanLogs.Enabled = true; // Re-enable the Scan Logs button since we didn't succeed in connecting to the device

                    notificationMessage("Destination does not respond", this.BackColor);

                    diagnosticMessage("Destination does not respond");
                }
            }
            catch (Exception)
            {

            }
        }

        private void bw_monitor_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                reportSuffixUpdatedRows initialPayload = (reportSuffixUpdatedRows)e.Argument;                

                logitemCollection thelogItems = initialPayload.updatedRows;

                string navpanelfullPath = initialPayload.additionalText;

                switches_threadRunning = true;

                BackgroundWorker worker = sender as BackgroundWorker;

                string dottedSuffix = ".";

                while (true == true)
                {
                    if (switches_monitorLogs) // This lets us abandon the loop
                    {
                        if (dottedSuffix.Length == 3)
                        {
                            dottedSuffix = "..";
                        }
                        else if (dottedSuffix.Length == 2)
                        {
                            dottedSuffix = ".";

                        }
                        else if (dottedSuffix.Length == 1)
                        {
                            dottedSuffix = "";
                        }
                        else if (dottedSuffix.Length == 0)
                        {
                            dottedSuffix = "...";
                        }

                        thelogItems = refreshlogsinDataset(thelogItems);

                        reportSuffixUpdatedRows suffixRowsPayload = new reportSuffixUpdatedRows();

                        suffixRowsPayload.suffixText = dottedSuffix;

                        suffixRowsPayload.updatedRows = thelogItems;

                        suffixRowsPayload.additionalText = navpanelfullPath;

                        worker.ReportProgress(0, suffixRowsPayload);

                        for (int i = 1; i < throttleDelay; i++)
                        {
                            if (!switches_monitorLogs)
                            {
                                break;
                            }

                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        e.Result = thelogItems;

                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void bw_monitor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            reportSuffixUpdatedRows suffixRowsPayload = (reportSuffixUpdatedRows)e.UserState;

            logitemCollection thelogItems = (logitemCollection)suffixRowsPayload.updatedRows; // Obtain updated logitem Collection

            string navpanefullPath = suffixRowsPayload.additionalText; // Obtain the navigation pane node being monitored

            if (navpanefullPath == tv_Logs.SelectedNode.FullPath)
            {
                updatedgvRows(thelogItems, false); // Render the updated logitem Collection                
            }

            notificationMessage("Monitoring logs " + suffixRowsPayload.additionalText + " " + suffixRowsPayload.suffixText, Color.Red);
        }

        private void bw_monitor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == false)
                {
                    switches_monitorLogs = false;

                    Bitmap imagemonitorLogs = new Bitmap(loadimagefromString(imagetextMonitor));

                    rb_Monitor.Image = imagemonitorLogs;

                    rb_Monitor.ToolTip = "Start monitoring device Logs";

                    notificationMessage("", this.BackColor);

                    switches_threadRunning = false;

                    diagnosticMessage("Stopped monitoring logs thread");

                    // Revert the treeview entries text colours to default

                    foreach (TreeNode tvNode in this.tv_Logs.Nodes)
                    {
                        foreach (TreeNode tvnodeCategory in tvNode.Nodes)
                        {
                            foreach (TreeNode tvnodeProduct in tvnodeCategory.Nodes)
                            {
                                tvnodeProduct.ForeColor = Color.Black;
                            }

                            tvnodeCategory.ForeColor = Color.Black;
                        }

                        tvNode.ForeColor = Color.Black;
                    }

                    // Revert the form title back to default

                    this.Text = c_productTitle;

                    // Hide the monitoring progress bar

                    tspb_Monitoring.Visible = false;
                }
            }
            catch (Exception)
            {

            }

            notificationMessage("", Color.LightBlue);
        }

        private void highlightandmovetodgvRow(DataGridView aGrid, bool highlightDirection, string sortColumn, bool moveSelected)
        {
            int intCount = 0; // The row index to be highlighted

            try
            {

                if (sortColumn != "")
                {
                    if (rcc_sortbyModified.Checked)
                    {
                        if (highlightDirection)
                        {
                            aGrid.Sort(aGrid.Columns[sortColumn], ListSortDirection.Ascending);
                        }
                        else
                        {
                            aGrid.Sort(aGrid.Columns[sortColumn], ListSortDirection.Descending);
                        }

                        aGrid.Refresh();
                    }
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (highlightDirection) // True is bottom\last DGV row
                {
                    intCount = aGrid.Rows.Count - 1;
                }
                else // False is top\first DGV row
                {
                    intCount = 0;
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (moveSelected)
                {
                    foreach (DataGridViewRow aRow in aGrid.Rows)
                    {
                        if (aRow.Index == (intCount))
                        {
                            aRow.Selected = true;
                        }
                        else
                        {
                            aRow.Selected = false;
                        }
                    }

                    aGrid.FirstDisplayedScrollingRowIndex = intCount;
                }
            }
            catch (Exception)
            {

            }
        }

        private void updatedgvRows(logitemCollection alogitemCollection, bool noColour)
        {
            dgv_Logs.SuspendLayout();

            try
            {
                logitemCollection dgvlogitemCollection = convertdgvtologItems(dgv_Logs.Rows);

                // Add new log files found in the dataset

                foreach (logItem verifylogItem in alogitemCollection)
                {
                    if (dgvlogitemCollection.Contains(verifylogItem.fulllogName) == null)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)dgv_Logs.Rows[0].Clone();

                        newRow.DefaultCellStyle.Font = new Font(globalfontName, globalfontSize, FontStyle.Regular);

                        newRow.Cells[0].Value = verifylogItem.fulllogName;
                        newRow.Cells[1].Value = verifylogItem.LogName;
                        newRow.Cells[2].Value = verifylogItem.logClass;
                        newRow.Cells[3].Value = verifylogItem.logType;
                        newRow.Cells[4].Value = verifylogItem.logSize;
                        newRow.Cells[5].Value = verifylogItem.logSize / 1024 / 1024;
                        newRow.Cells[6].Value = verifylogItem.loglastModified;

                        newRow.Cells[7].Value = verifylogItem.fulllogName.Substring(0, verifylogItem.fulllogName.LastIndexOf(@"\")); ;

                        newRow.Cells[8].Value = verifylogItem.logProduct;

                        newRow.Visible = true;

                        if (verifylogItem.fulllogName.Substring(verifylogItem.fulllogName.Length - c_archivelog_Extension.Length, c_archivelog_Extension.Length) == c_archivelog_Extension && rcb_hidearchiveLogs.Checked)
                        {

                        }
                        else
                        {
                            dgv_Logs.Rows.Add(newRow);
                        }
                    }
                    else
                    {

                    }
                }

                // Compile list of log files no longer in the dataset

                List<int> logstobeRemoved = new List<int>();

                foreach (logItem verifylogItem in dgvlogitemCollection)
                {
                    if (alogitemCollection.Contains(verifylogItem.fulllogName) == null)
                    {
                        logstobeRemoved.Add(Convert.ToInt32(dgvlogitemCollection.Contains(verifylogItem.fulllogName)));
                    }
                }

                // Remove the log files from the dgv_Logs dgv

                logstobeRemoved.Reverse();

                foreach (int logindexValue in logstobeRemoved)
                {
                    dgv_Logs.Rows.RemoveAt(logindexValue);
                }

                foreach (DataGridViewRow aRow in dgv_Logs.Rows)
                {
                    foreach (logItem alogItem in alogitemCollection)
                    {
                        if (alogItem.fulllogName == aRow.Cells["dgv_c_hiddenlogName"].Value.ToString())
                        {
                            if (aRow.Cells["dgv_c_lastWritten"].Value.ToString() != alogItem.loglastModified.ToString()) // Row needs updated colour
                            {
                                aRow.Cells["dgv_c_logSize"].Value = alogItem.logSize;
                                aRow.Cells["dgv_c_logsizeMB"].Value = alogItem.logSize / 1024 / 1024;
                                aRow.Cells["dgv_c_lastWritten"].Value = alogItem.loglastModified;

                                if (!noColour)
                                {
                                    aRow.DefaultCellStyle.BackColor = colourList[0];
                                }
                            }
                            else // Row needs to be colour cycled since the log hasn't been updated
                            {
                                if (!noColour)
                                {
                                    for (int i = 0; i < colourList.Count; i++)
                                    {
                                        if (aRow.DefaultCellStyle.BackColor.Name.ToLower() == colourList[i].Name.ToLower())
                                        {
                                            if (i < colourList.Count - 1)
                                            {
                                                aRow.DefaultCellStyle.BackColor = colourList[i + 1];

                                                break;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            break; // Match found so loop can be stopped
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            if (rcc_sortbyModified.Checked)
            {
                highlightandmovetodgvRow(dgv_Logs, false, "dgv_c_lastWritten", false);
            }

            dgv_Logs.ResumeLayout();
        }

        private logitemCollection retrievelogsfromGlobal(string logProduct, string targetDevice)
        {
            logitemCollection outboundCollection = new logitemCollection();

            try
            {
                foreach (logItem alogItem in globallogitemCollection)
                {
                    if (alogItem.logDevice == targetDevice)
                    {
                        if (alogItem.logClass == logProduct)
                        {
                            outboundCollection.Add(alogItem);
                        }
                        else if (alogItem.logProduct == logProduct)
                        {
                            outboundCollection.Add(alogItem);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return outboundCollection;
        }

        private logitemCollection convertdgvtologItems(object theRows)
        {
            logitemCollection alogitemCollection = new logitemCollection();

            if (theRows.GetType() == typeof(System.Windows.Forms.DataGridViewRowCollection))
            {
                foreach (DataGridViewRow dgvRow in (DataGridViewRowCollection)theRows)
                {
                    try
                    {
                        logItem alogItem = new logItem();

                        alogItem.fulllogName = dgvRow.Cells["dgv_c_hiddenlogName"].Value.ToString();
                        alogItem.LogName = dgvRow.Cells["dgv_c_logName"].Value.ToString();
                        alogItem.logClass = dgvRow.Cells["dgv_c_Class"].Value.ToString();
                        alogItem.logType = dgvRow.Cells["dgv_c_Type"].Value.ToString();
                        alogItem.logSize = (long)dgvRow.Cells["dgv_c_logSize"].Value;
                        alogItem.loglastModified = (DateTime)dgvRow.Cells["dgv_c_lastWritten"].Value;
                        alogItem.logLocation = dgvRow.Cells["dgv_c_logPath"].Value.ToString();
                        alogItem.logProduct = dgvRow.Cells["dgv_v_Product"].Value.ToString();

                        alogitemCollection.Add(alogItem);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            if ((theRows.GetType() == typeof(System.Windows.Forms.DataGridViewSelectedRowCollection)))
            {
                foreach (DataGridViewRow dgvRow in (DataGridViewSelectedRowCollection)theRows)
                {
                    try
                    {
                        logItem alogItem = new logItem();

                        alogItem.fulllogName = dgvRow.Cells["dgv_c_hiddenlogName"].Value.ToString();
                        alogItem.LogName = dgvRow.Cells["dgv_c_logName"].Value.ToString();
                        alogItem.logClass = dgvRow.Cells["dgv_c_Class"].Value.ToString();
                        alogItem.logType = dgvRow.Cells["dgv_c_Type"].Value.ToString();
                        alogItem.logSize = (long)dgvRow.Cells["dgv_c_logSize"].Value;
                        alogItem.loglastModified = (DateTime)dgvRow.Cells["dgv_c_lastWritten"].Value;
                        alogItem.logLocation = dgvRow.Cells["dgv_c_logPath"].Value.ToString();
                        alogItem.logProduct = dgvRow.Cells["dgv_v_Product"].Value.ToString();

                        alogitemCollection.Add(alogItem);
                    }
                    catch (Exception)
                    {

                    }
                }
            }            

            return alogitemCollection;
        }

        private void openLogFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Open log folder

            try
            {
                List<string> historicallogpathList = new List<string>();

                foreach (DataGridViewRow alogRow in dgv_Logs.SelectedRows)
                {
                    string logPath = alogRow.Cells["dgv_c_logPath"].Value.ToString(); ;

                    if (!historicallogpathList.Contains(logPath))
                    {
                        historicallogpathList.Add(logPath);

                        ProcessStartInfo newProcess = new ProcessStartInfo();

                        newProcess.FileName = logPath;

                        newProcess.Arguments = "";

                        newProcess.CreateNoWindow = false;

                        newProcess.UseShellExecute = true;

                        try
                        {
                            Process.Start(newProcess);
                        }
                        catch (Exception ee)
                        {
                            notificationMessage("Could not open folder " + ee.Message, this.BackColor);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion opening log folder - " + ee.Message);
            }
        }

        private void openLogFolderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            launchLogs(dgv_Logs.SelectedRows);
        }

        private void tsmi_zipselectedlogs_Click(object sender, EventArgs e)
        {
            if (dgv_Logs.SelectedRows.Count != 0)
            {

                logitemCollection dgvlogitemCollection = convertdgvtologItems(dgv_Logs.SelectedRows);

                TreeNode selectedTreeNode = tv_Logs.SelectedNode;

                // Form up the list of logs from the selected datagridview rows that will be zipped up

                string zipfileName = Path.Combine(rtb_zipoutputDirectory.TextBoxText, selectedTreeNode.FullPath.ToString().Replace(@"\", "-") + "-Selection-" + DateTime.Now.ToString("dd-MM-HH-mm") + ".zip");

                notificationMessage("Zipping log files ...", this.BackColor);

                diagnosticMessage("Zipping log files into " + zipfileName);

                zipLogs(dgvlogitemCollection, zipfileName);
            }
            else
            {
                notificationMessage("Zip not performed, nothing selected", this.BackColor);
            }
        }

        private void dgv_Logging_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!switches_startupPhase)
            {
                try
                {
                    string componentName = dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_componentName"].Value.ToString();

                    RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName()); // &&& Won't work

                    remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing\" + componentName, true);

                    string dfdew = dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_debugLogging"].Value.ToString().ToLower();

                    for (int i = 1; i < dgv_Logging.ColumnCount; i++)
                    {
                        switch (dgv_Logging.Columns[i].Name)
                        {
                            case "c_dgv_logging_debugLogging":

                                if (dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_debugLogging"].Value.ToString().ToLower() == "true")
                                {
                                    remoteHK.SetValue("DebugLogging", "1", RegistryValueKind.DWord);
                                }
                                else
                                {
                                    remoteHK.SetValue("DebugLogging", "0", RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_Enabled":

                                if (dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_Enabled"].Value.ToString().ToLower() == "true")
                                {
                                    remoteHK.SetValue("Enabled", "1", RegistryValueKind.DWord);
                                }
                                else
                                {
                                    remoteHK.SetValue("Enabled", "0", RegistryValueKind.DWord);
                                }

                                break;
                            case "c_dgv_logging_loggingLevel":

                                int logginglevelValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_loggingLevel"].Value.ToString(), out logginglevelValue))
                                {
                                    remoteHK.SetValue("LoggingLevel", logginglevelValue, RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_logmaxHistory":

                                int logmaxhistoryValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_logmaxHistory"].Value.ToString(), out logmaxhistoryValue))
                                {
                                    remoteHK.SetValue("LogMaxHistory", logmaxhistoryValue, RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_maxfileSize":

                                int maxfilesizeValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_maxfileSize"].Value.ToString(), out maxfilesizeValue))
                                {
                                    remoteHK.SetValue("MaxFileSize", maxfilesizeValue, RegistryValueKind.DWord);
                                }

                                break;
                        }
                    }
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not set Sites logging settings - " + ee.Message);
                }
            }
        }

        private void cb_site_siteLogging_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_siteLogging.Checked)
                {
                    remoteHK.SetValue("Enabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("Enabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites Logging Enabled property - " + ee.Message);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_sqlLogging.Checked)
                {
                    remoteHK.SetValue("SqlEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("SqlEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites SQL Enabled property - " + ee.Message);
            }
        }

        private void cb_site_archiveLogs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_archiveLogs.Checked)
                {
                    remoteHK.SetValue("ArchiveEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("ArchiveEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites Archive Enabled property - " + ee.Message);
            }
        }

        private void num_provider_loggingLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("Logging Level", num_provider_loggingLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers Logging Level property - " + ee.Message);
            }
        }

        private void num_provider_sqlcacheloggingLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("SQL Cache Logging Level", num_provider_sqlcacheloggingLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers SQL Cache Logging Level property - " + ee.Message);
            }
        }

        private void num_provider_logsizeMb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("Log Size Mb", num_provider_logsizeMb.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers Log Size Mb property - " + ee.Message);
            }
        }

        private void cb_client_debugLogging_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                if (cb_client_Logging.Checked)
                {
                    remoteHK.SetValue("LogEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("LogEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Logging property - " + ee.Message);
            }
        }

        private void cb_client_debugLogging_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cb_client_debugLogging.Checked)
                {

                    if (!regkeyExist(gettvselectednodedeviceName(), "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                    {
                        RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                        remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                        remoteHK.CreateSubKey("DebugLogging");

                        nud_client_logLevel.Value = 0;
                    }
                }
                else
                {
                    if (regkeyExist(gettvselectednodedeviceName(), "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                    {
                        RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                        remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                        remoteHK.DeleteSubKey("DebugLogging");

                        nud_client_logLevel.Value = 1;
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Debug Logging property - " + ee.Message);
            }
        }

        private void nud_client_logLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogLevel", nud_client_logLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Level property - " + ee.Message);
            }
        }

        private void nud_client_logmaxHistory_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogMaxHistory", nud_client_logmaxHistory.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Max History property - " + ee.Message);
            }
        }

        private void nud_client_logmaxSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), gettvselectednodedeviceName());

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogMaxSize", nud_client_logmaxSize.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Max Size property - " + ee.Message);
            }
        }

        private void b_cycleCCMEXEC_Click(object sender, EventArgs e)
        {
            diagnosticMessage("Recycling the CCMEXEC Service");

            servicecycleMessage aservicecycleMessage = new servicecycleMessage();

            aservicecycleMessage.remoteServer = gettvselectednodedeviceName();
            
            aservicecycleMessage.serviceName = "CCMEXEC";

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_serviceCycle_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_serviceCycle_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_serviceCycle_RunWorkerCompleted);

            b_cycleCCMEXEC.Enabled = false;

            bw.RunWorkerAsync(aservicecycleMessage);
        }

        private void b_cycleSMSEXEC_Click(object sender, EventArgs e)
        {
            diagnosticMessage("Recycling the SMSEXEC Service");

            servicecycleMessage aservicecycleMessage = new servicecycleMessage();
 
            aservicecycleMessage.remoteServer = gettvselectednodedeviceName();            

            aservicecycleMessage.serviceName = "SMS_EXECUTIVE";

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_serviceCycle_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_serviceCycle_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_serviceCycle_RunWorkerCompleted);

            b_cycleSMSEXEC.Enabled = false;

            bw.RunWorkerAsync(aservicecycleMessage);
        }

        private void initiatedeviceScan(string targetDevice)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_connectdevice_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_connectdevice_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_connectdevice_RunWorkerCompleted);

            bw.RunWorkerAsync(targetDevice);
        }

        private void removedevicefromGlobal(string deviceName)
        {
            //try
            //{
                List<int> removalList = new List<int>();

                foreach (logItem alogItem in globallogitemCollection)
                {
                    string finaldeviceName = "";

                    if (alogItem.logDevice == null) // Try and get the device name from the full log path if that isn't null as well
                    {
                        if (!alogItem.fulllogName.Equals(null))
                        {
                        string chopping = alogItem.fulllogName.Substring(2, alogItem.fulllogName.Length - 2);                        

                        finaldeviceName = chopping.Substring(0, chopping.IndexOf(@"\"));
                        }
                    }
                    else
                    {
                        finaldeviceName = alogItem.logDevice;
                    }

                    if (finaldeviceName.ToUpper() == deviceName.ToUpper())
                    {
                        if (alogItem.fulllogName.Equals(null)) // Trap for an error being seen with null data appearing in the global log collection
                        {
                        }

                    removalList.Add(Convert.ToInt16(globallogitemCollection.Contains(alogItem.fulllogName)));
                    }
                }

                removalList.Reverse();

                foreach (int anInt in removalList)
                {
                    globallogitemCollection.Remove(anInt);
                }
            //}
            //catch (Exception ee)
            //{
            //    string wewew = "2l";
            //}
        }

        private void removedevicefromnnavigationPanel(string deviceName)
        {
            tv_Logs.BeginUpdate();
            
            foreach (TreeNode mainNodes in tv_Logs.Nodes)
            {
                if (mainNodes.Text.ToUpper() == deviceName.ToUpper())
                {
                    try
                    {
                        foreach (TreeNode achildNode in mainNodes.Nodes)
                        {
                            foreach (TreeNode anotherchildNode in achildNode.Nodes)
                            {
                                try
                                {
                                    anotherchildNode.Remove();
                                }
                                catch (Exception)
                                {

                                }
                            }

                            try
                            {
                                achildNode.Remove();
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        mainNodes.Remove();
                    }
                    catch (Exception)
                    {

                    }

                    break;
                }
            }

            tv_Logs.EndUpdate();
        }

        private void scanLogs(string devicescanTarget)
        {
            afterselectDisabled = true; // Disable tv_Logs afterSelect event

            // Check if this device has already been scanned

            bool alreadyExists = false;

            foreach (TreeNode atreeNode in tv_Logs.Nodes)
            {
                if (atreeNode.Text.ToUpper() == devicescanTarget.ToUpper()) alreadyExists = true;
            }

            if (alreadyExists)
            {
                // Remove the data for this device from the Global dataset

                notificationMessage("Purging scan data for this device", this.BackColor);

                removedevicefromGlobal(devicescanTarget);                

                removedevicefromnnavigationPanel(devicescanTarget);              

                notificationMessage("Device scan data purged", this.BackColor);
            }

            afterselectDisabled = false; // Enable tv_Logs afterSelect event

            try
            {
                if (!switches_scan_threadRunning && !switches_threadRunning)
                {
                    rb_scanLogs.Enabled = false;

                    if (globalautoswitchlogsPanel)
                    {
                        panel_customLocations.Visible = false;
                        panel_Logs.Visible = true;                        
                        panel_Logging.Visible = false;
                        panel_Help.Visible = false;
                        panel_Diagnostics.Visible = false;

                        globalautoswitchlogsPanel = false; // Set the dead mans switch so the change the logs panel is not performed again
                    }

                    dgv_Logs.Rows.Clear();

                    // Check if destination exists, query a basic Windows Operating System registry key

                    notificationMessage("Checking destination is ready for us", this.BackColor);

                    initiatedeviceScan(devicescanTarget);
                }
                else
                {
                    if (switches_scan_threadRunning)
                    {
                        diagnosticMessage("Scan thread is already running");
                    }

                    if (switches_threadRunning)
                    {
                        diagnosticMessage("Turn off monitoring before scanning for logs again");
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error during scanning of logs - " + ee.Message);
            }
        }

        private void rb_scanLogs_Click(object sender, EventArgs e)
        {
            if (!switches_threadRunning)
            {
                scanLogs(rcb_remoteServer.TextBoxText.ToUpper());
            }
            else
            {
                notificationMessage("Stop Monitoring feature to Scan another device", this.BackColor);
            }
        }

        private void rcb_remoteServer_TextBoxTextChanged(object sender, EventArgs e)
        {

        }

        private void rcc_Oldest_Click(object sender, EventArgs e)
        {
            ColorDialog colourDialog = new ColorDialog();

            colourDialog.Color = rcc_Oldest.Color;

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                rcc_Oldest.Color = colourDialog.Color;

                gradientcolourEnd = colourDialog.Color;
            }

            updateGradient();

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "GradientEndColour", Convert.ToString(rcc_Oldest.Color.ToArgb()));
        }

        private void rcc_Newest_Click(object sender, EventArgs e)
        {
            ColorDialog colourDialog = new ColorDialog();

            colourDialog.Color = rcc_Newest.Color;

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                rcc_Newest.Color = colourDialog.Color;

                gradientcolourStart = colourDialog.Color;
            }

            updateGradient();

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "GradientEndColour", Convert.ToString(rcc_Newest.Color.ToArgb()));
        }

        private void rcb_hidearchiveLogs_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "HideArchiveLogs", Convert.ToString(rcb_hidearchiveLogs.Checked));

            if (rcb_hidearchiveLogs.Checked)
            {
                switches_hide_archiveLogs = true;

                dgv_Logs.Columns["dgv_c_Type"].Visible = false;

                renderLogs(true, "");
            }
            else
            {
                switches_hide_archiveLogs = false;

                dgv_Logs.Columns["dgv_c_Type"].Visible = true;

                renderLogs(true, "");
            }

            notificationMessage(this.tv_Logs.SelectedNode.Text + " contains " + dgv_Logs.Rows.Count.ToString() + " objects - " + getSaying(), this.BackColor);
        }

        private void beginMonitoring()
        {
            dgv_Logs.ClearSelection();

            try
            {
                if (!switches_threadRunning && !switches_monitorLogs)
                {
                    if (!tv_Logs.SelectedNode.FullPath.Contains(@"\"))
                    {
                        diagnosticMessage("Cannot monitor node " + tv_Logs.SelectedNode.Text + ", no real reason to monitor every log");

                        notificationMessage("Cannot monitor node " + tv_Logs.SelectedNode.Text + ", no real reason to monitor every log", this.BackColor);
                    }
                    else
                    {
                        try
                        {
                            Bitmap imagemonitorlogsStop = new Bitmap(loadimagefromString(imagetextmonitorStop));

                            rb_Monitor.Image = imagemonitorlogsStop;

                            rb_Monitor.ToolTip = "Stop monitoring device Logs";
                        }
                        catch (Exception)
                        {

                        }

                        this.tv_Logs.SelectedNode.ForeColor = Color.Green; // Change selected treeview node foreground color to show it is being monitored

                        // Refresh the stale state data for the rows in dgv_Logs - Monitoring might be initiated by the user a while after opening, making logs in view stale

                        logitemCollection alogitemCollection = refreshlogsinDataset(convertdgvtologItems(dgv_Logs.Rows));

                        // Start the monitoring thread

                        switches_monitorLogs = true;

                        BackgroundWorker bw = new BackgroundWorker();
                        bw.WorkerSupportsCancellation = true;
                        bw.WorkerReportsProgress = true;
                        bw.DoWork +=
                            new DoWorkEventHandler(bw_monitor_DoWork);
                        bw.ProgressChanged +=
                            new ProgressChangedEventHandler(bw_monitor_ProgressChanged);
                        bw.RunWorkerCompleted +=
                            new RunWorkerCompletedEventHandler(bw_monitor_RunWorkerCompleted);

                        // We will give the monitoring thread a subset of the global data based on what is selected in the treeview

                        string deviceTarget = "";

                        deviceTarget = gettvselectednodedeviceName();

                        logitemCollection tosendlogitemCollection = retrievelogsfromGlobal(tv_Logs.SelectedNode.Text, deviceTarget);

                        reportSuffixUpdatedRows initialPayload = new reportSuffixUpdatedRows();

                        initialPayload.updatedRows = tosendlogitemCollection;

                        initialPayload.additionalText = tv_Logs.SelectedNode.FullPath;

                        bw.RunWorkerAsync(initialPayload);

                        monitortargetList.Add(tv_Logs.SelectedNode.FullPath); // Add this device to the global monitor list

                        diagnosticMessage("Monitoring thread started");

                        this.Text = c_productTitle + " - Monitoring " + deviceTarget;

                        tspb_Monitoring.Visible = true;
                    }
                }
                else // Thread must be running, the user is asking us to stop it
                {
                    monitortargetList.Remove(tv_Logs.SelectedNode.FullPath); // Remove this device from the global monitor list

                    switches_monitorLogs = false;

                    diagnosticMessage("Closing thread");

                    Thread.Sleep(100);
                }
            }
            catch (Exception ee)
            {
                switches_monitorLogs = false; // Tell the thread to terminate

                diagnosticMessage("Could not spawn the monitoring thread - " + ee.Message);
            }
        }

        private void rb_Monitor_Click(object sender, EventArgs e)
        {
            beginMonitoring();
        }

        private void refreshLogs() /// Only call run from UI thread
        {
            if (!switches_scan_threadRunning && !switches_threadRunning)
            {
                notificationMessage("Refreshing logs in current view", this.BackColor);
                
                logitemCollection tosendlogitemCollection = convertdgvtologItems(dgv_Logs.Rows);

                tosendlogitemCollection = refreshlogsinDataset(tosendlogitemCollection);

                updatedgvRows(tosendlogitemCollection, true); // Render the updated logitem Collection

                notificationMessage("Refreshed logs in current view", this.BackColor);
            }
            else
            {
                if (switches_scan_threadRunning)
                {
                    diagnosticMessage("Scan thread is already running");
                }

                if (switches_threadRunning)
                {
                    diagnosticMessage("Turn off monitoring before refreshing the view");
                }
            }
        }

        private void rb_refreshLogs_Click(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void rb_openLogs_Click(object sender, EventArgs e)
        {
            launchLogs(dgv_Logs.SelectedRows);
        }

        private void rb_Logging_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Logging.Rows.Clear(); // Clear the dgv_Logging DGV so we're looking at fresh data

                TreeNode selectedNode = tv_Logs.SelectedNode; // Get treeview selected node to determine device being focused on

                string deviceTarget = "";

                deviceTarget = gettvselectednodedeviceName();                

                // Check if this device is allowed to display the Client panel

                loggingpanelDevice aloggingpanelDevice = new loggingpanelDevice();

                aloggingpanelDevice.loggingType = "Client";
                aloggingpanelDevice.deviceName = deviceTarget;

                if (globalloggingpaneldevicesCollection.Contains(aloggingpanelDevice))
                {
                    diagnosticMessage("Retrieving Client Logging data");
                    populateclientPanel(deviceTarget);
                    diagnosticMessage("Retrieved Client Logging data");
                    p_Client.Visible = true;
                }
                else
                {
                    p_Client.Visible = false;
                }

                aloggingpanelDevice.loggingType = "Server";
                aloggingpanelDevice.deviceName = deviceTarget;

                if (globalloggingpaneldevicesCollection.Contains(aloggingpanelDevice))
                {
                    diagnosticMessage("Retrieving Site Server Logging data");

                    populateserverPanel(deviceTarget);

                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerSupportsCancellation = true;
                    bw.WorkerReportsProgress = true;
                    bw.DoWork +=
                        new DoWorkEventHandler(bw_logging_DoWork);
                    bw.ProgressChanged +=
                        new ProgressChangedEventHandler(bw_logging_ProgressChanged);
                    bw.RunWorkerCompleted +=
                        new RunWorkerCompletedEventHandler(bw_logging_RunWorkerCompleted);

                    if (deviceTarget != null && deviceTarget != "")
                    {
                        bw.RunWorkerAsync(deviceTarget);

                        dgv_Logging.Visible = true;

                        p_Site.Visible = true;
                    }
                }
                else
                {
                    p_Site.Visible = false;
                    dgv_Logging.Visible = false;
                }

                panel_Logs.Visible = false;
                panel_customLocations.Visible = false;
                panel_Help.Visible = false;
                panel_Diagnostics.Visible = false;
                panel_Logging.Visible = true;
            }
            catch (Exception ee)
            {

            }
        }

        private void rup_Duration_DownButtonClicked(object sender, MouseEventArgs e)
        {
            int currentValue = Convert.ToInt16(rup_Duration.Value);

            if (currentValue > 3)
            {
                currentValue--;
            }

            if (Convert.ToInt16(rup_Duration.Value) != currentValue)
            {
                rup_Duration.Value = currentValue.ToString();
                rup_Duration.TextBoxText = currentValue.ToString();

                throttleDelay = Convert.ToInt16(rup_Duration.Value);

                updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MonitoringTimerDuration", Convert.ToString(rup_Duration.Value));
            }
        }

        private void rup_Duration_UpButtonClicked(object sender, MouseEventArgs e)
        {
            int currentValue = Convert.ToInt16(rup_Duration.Value);

            if (currentValue < 60)
            {
                currentValue++;
            }

            if (Convert.ToInt16(rup_Duration.Value) != currentValue)
            {
                rup_Duration.Value = currentValue.ToString();
                rup_Duration.TextBoxText = currentValue.ToString();

                throttleDelay = Convert.ToInt16(rup_Duration.Value);

                updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MonitoringTimerDuration", Convert.ToString(rup_Duration.Value));
            }
        }

        private void rup_Duration_TextBoxValidated(object sender, EventArgs e)
        {
            if (!switches_startupPhase)
            {
                if (rup_Duration.TextBoxText != "")
                {

                    if (Convert.ToInt16(rup_Duration.TextBoxText) > 2)
                    {
                        rup_Duration.Value = rup_Duration.TextBoxText;

                        throttleDelay = Convert.ToInt16(rup_Duration.Value);

                        updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MonitoringTimerDuration", Convert.ToString(rup_Duration.Value));
                    }
                    else
                    {
                        rup_Duration.Value = "3";
                        rup_Duration.TextBoxText = "3";
                    }
                }
                else
                {
                    rup_Duration.Value = "3";
                    rup_Duration.TextBoxText = "3";
                }
            }
        }

        private void rb_debugWindow_Click(object sender, EventArgs e)
        {
            panel_Logs.Visible = false;
            panel_Logging.Visible = false;
            panel_customLocations.Visible = false;
            panel_Help.Visible = false;
            panel_Diagnostics.Visible = true;

            highlightandmovetodgvRow(dgv_Diagnostics, true, "", true);
        }

        private void renderlocationsDGV()
        {
            try
            {
                // Get custom log locations and populate the datagridview

                string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                dgv_customLocations.Rows.Clear();

                if (customlogLocations != null)
                {
                    foreach (string customlogLocation in customlogLocations)
                    {
                        try
                        {
                            string[] splitElements = customlogLocation.Split('|');

                            try
                            {
                                if (splitElements.Count() == 5)
                                {
                                    DataGridViewRow newRow = (DataGridViewRow)dgv_customLocations.Rows[0].Clone();

                                    newRow.Cells[0].Value = splitElements[0];
                                    newRow.Cells[1].Value = splitElements[1];
                                    newRow.Cells[2].Value = splitElements[2];
                                    newRow.Cells[3].Value = splitElements[3];
                                    newRow.Cells[4].Value = splitElements[4];

                                    newRow.Visible = true;

                                    dgv_customLocations.Rows.Add(newRow);
                                }
                            }
                            catch (Exception) // Handle this being the first row in the DGV by creating a new row
                            {
                                if (splitElements.Count() == 5)
                                {
                                    dgv_customLocations.Rows.Add();

                                    DataGridViewRow newRow = (DataGridViewRow)dgv_customLocations.Rows[0].Clone();

                                    dgv_customLocations.Rows.Clear();

                                    newRow.Cells[0].Value = splitElements[0];
                                    newRow.Cells[1].Value = splitElements[1];
                                    newRow.Cells[2].Value = splitElements[2];
                                    newRow.Cells[3].Value = splitElements[3];
                                    newRow.Cells[4].Value = splitElements[4];

                                    newRow.Visible = true;

                                    dgv_customLocations.Rows.Add(newRow);
                                }
                            }
                        }
                        catch (Exception ee)
                        {
                            string weerwew = ee.Message;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void rb_customPaths_Click(object sender, EventArgs e)
        {
            renderlocationsDGV();

            panel_Logs.Visible = false;
            panel_Logging.Visible = false;
            panel_customLocations.Visible = true;
            panel_Help.Visible = false;
            panel_Diagnostics.Visible = false;
        }

        private void rb_Help_Click(object sender, EventArgs e)
        {
            panel_Logs.Visible = false;
            panel_Logging.Visible = false;
            panel_customLocations.Visible = false;
            panel_Help.Visible = true;
            panel_Diagnostics.Visible = false;
        }

        private void b_addupdateLocation_Click(object sender, EventArgs e)
        {
            if (tb_customLocation.Text != "" && tb_fileMask.Text != "" && tb_logCategory.Text != "" && tb_logProduct.Text != "")
            {
                try
                {
                    string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                    bool updatedTrigger = false;

                    // Does entry already exist, update it

                    List<string> writebackList = new List<string>();

                    if (customlogLocations != null)
                    {
                        foreach (string customlogLocation in customlogLocations)
                        {
                            try
                            {
                                string[] splitElements = customlogLocation.Split('|');

                                string newcustomlogLocation = customlogLocation;

                                if (splitElements[0] == tb_customLocation.Text) // Found a match
                                {
                                    updatedTrigger = true;

                                    newcustomlogLocation = tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text;
                                }

                                if (newcustomlogLocation != "" || newcustomlogLocation != null)
                                {
                                    writebackList.Add(newcustomlogLocation);
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }

                        // Put the customLogLocations value back

                        if (!updatedTrigger)
                        {
                            writebackList.Add(tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text);
                        }
                    }
                    else
                    {
                        writebackList.Add(tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text);
                    }

                    try
                    {
                        RegistryKey hkcucustomLocations = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMSMarshall\LogLauncher", true);

                        if (hkcucustomLocations != null)
                        {
                            hkcucustomLocations.SetValue("CustomLogLocations", writebackList.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                    }

                    renderlocationsDGV();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                notificationMessage("All fields must be populated", this.BackColor);
            }
        }

        private void b_deleteLocation_Click(object sender, EventArgs e)
        {
            if (tb_customLocation.Text != "")
            {
                try
                {
                    string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                    List<string> writebackList = new List<string>();

                    foreach (DataGridViewRow theRows in dgv_customLocations.SelectedRows)
                    {
                        foreach (string customlogLocation in customlogLocations)
                        {
                            string[] splitElements = customlogLocation.Split('|');

                            if (splitElements[0].ToLower() != theRows.Cells[0].Value.ToString().ToLower())
                            {
                                writebackList.Add(splitElements[0] + "|" + splitElements[1] + "|" + Convert.ToString(splitElements[2]) + "|" + splitElements[3] + "|" + splitElements[4]);
                            }
                        }
                    }

                    try
                    {
                        RegistryKey hkcucustomLocations = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMSMarshall\LogLauncher", true);

                        if (hkcucustomLocations != null)
                        {
                            hkcucustomLocations.SetValue("CustomLogLocations", writebackList.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                    }

                    renderlocationsDGV();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                notificationMessage("Custom Location field has to be populated", this.BackColor);
            }
        }

        private void dgv_customLocations_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dgv_customLocations.SelectedRows;

                foreach (DataGridViewRow theRow in selectedRows)
                {
                    tb_customLocation.Text = (string)theRow.Cells["c_cust_customLocation"].Value;
                    tb_fileMask.Text = (string)theRow.Cells["c_cust_fileMask"].Value;
                    cb_recurseFolder.Text = (string)theRow.Cells["c_cust_recurseFolder"].Value;
                    tb_logCategory.Text = (string)theRow.Cells["c_cust_logClass"].Value; ;
                    tb_logProduct.Text = (string)theRow.Cells["c_cust_logProduct"].Value;
                }
            }
            catch (Exception)
            {

            }
        }

        private void rcb_MultiMerge_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "MultiMergeSingleTrace", Convert.ToString(rcb_MultiMerge.Checked));

            if (rcb_MultiMerge.Checked)
            {
                switches_open_multipleLogs = true;
            }
            else
            {
                switches_open_multipleLogs = false;
            }
        }

        private void rb_showLogs_Click(object sender, EventArgs e)
        {
            panel_Logs.Visible = true;
            panel_Logging.Visible = false;
            panel_customLocations.Visible = false;
            panel_Help.Visible = false;
            panel_Diagnostics.Visible = false;
        }

        private void writelogscolumnOrder(DataGridViewColumnCollection dgvColumns)
        {
            try
            {
                List<string> columnorderList = new List<string>();

                foreach (DataGridViewColumn dgvColumn in dgvColumns)
                {
                    columnorderList.Add(dgvColumn.DisplayIndex.ToString());
                }

                setregkeyValues("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "LogsColumnOrder", columnorderList.ToArray());
            }
            catch (Exception ee)
            {
                diagnosticMessage("Couldn't write Logs column order to registry - " + ee.Message);
            }
        }

        private void dgv_Logs_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                int displayindexCeiling = 0;


                foreach (DataGridViewColumn dgvColumn in dgv_Logs.Columns)
                {
                    dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    if (dgvColumn.DisplayIndex > displayindexCeiling)
                    {

                    }
                }

                dgv_Logs.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                writelogscolumnOrder(dgv_Logs.Columns);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error while handling column change - " + ee.Message);
            }
        }

        private void rb_supportCenter_Click(object sender, EventArgs e)
        {
            if (supportcenterPath != "")
            {
                ProcessStartInfo newProcess = new ProcessStartInfo();

                newProcess.FileName = supportcenterPath;

                if (tv_Logs.SelectedNode.Parent == null)
                {
                    newProcess.Arguments = tv_Logs.SelectedNode.Text;
                }
                else
                {
                    newProcess.Arguments = gettvselectednodedeviceName();
                }

                newProcess.CreateNoWindow = false;

                newProcess.UseShellExecute = false;

                try
                {
                    Process.Start(newProcess);
                }
                catch (Exception ee)
                {
                    notificationMessage("Could not start ConfigMgr Support Center" + ee.Message, this.BackColor);
                }
            }
        }

        private void rb_tracerFind_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.SystemDirectory;
            openFileDialog1.Filter = "Tracer (*.exe)|*.exe";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Locate a Tracing Tool";

            DialogResult result = openFileDialog1.ShowDialog();

            string tempTracerPath = openFileDialog1.FileName;

            if (result == DialogResult.OK) // Set for current session, and store in registry
            {
                if (File.Exists(tempTracerPath))
                {
                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "TracerPath", tempTracerPath);

                    TracerPath = tempTracerPath;

                    rtb_tracerPath.TextBoxText = tempTracerPath;
                    rtb_tracerPath.Value = tempTracerPath;
                    rtb_tracerPath.Text = "Tracer";

                }
            }
        }

        private void rtb_Help_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText.ToString()); // Default Browser            
        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonOrbMenuItem5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rcb_remoteServer_TextBoxValidated(object sender, EventArgs e)
        {
            string targetDevice = rcb_remoteServer.TextBoxText.ToUpper();

            if (targetDevice != "")
            {
                scanLogs(targetDevice);
            }
        }

        private void dgv_Logs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) // Check if non-Enter key pressed
            {
                if (e.KeyData == Keys.F5)
                {
                    refreshLogs();
                }
                else
                {
                    try
                    {
                        if (DateTime.Now - searchkeypressLast > new TimeSpan(0, 0, 1)) // Check if the last keypress time has expired
                        {
                            searchkeypressText = e.KeyData.ToString().ToLower();
                        }
                        else // Expired, so build up the search string
                        {
                            searchkeypressText += e.KeyData.ToString().ToLower();
                        }

                        searchkeypressLast = DateTime.Now;

                        // Search the DGV for the string

                        int searchRow = 0;

                        bool searchfoundrowSwitch = false;

                        for (int i = 0; i < Convert.ToInt16(dgv_Logs.Rows.Count); i++)
                        {
                            if (dgv_Logs.Rows[i].Cells["dgv_c_logName"].Value.ToString().ToLower().StartsWith(searchkeypressText))
                            {
                                searchRow = i;
                                searchfoundrowSwitch = true;
                                break;
                            }
                        }

                        if (searchfoundrowSwitch) // We have a match
                        {
                            foreach (DataGridViewRow adgvRow in dgv_Logs.Rows)
                            {
                                adgvRow.Selected = false;
                            }

                            dgv_Logs.FirstDisplayedScrollingRowIndex = searchRow;

                            dgv_Logs.Rows[searchRow].Selected = true;
                        }
                    }
                    catch (Exception ee)
                    {
                        diagnosticMessage("Error during Logs datagrid searching - " + ee.Message);
                    }
                }
            }
            else // Enter was pressed, so handle log opening (triyng to work out how to stop the row skip in the dgv_Logs dgv
            {
                launchLogs(dgv_Logs.SelectedRows);

                e.Handled = true;

                //e.KeyChar = (char)0;

                // return;
            }
        }

        private void rcc_ignoreCRASHDUMP_Click(object sender, EventArgs e)
        {
            rcc_ignoreCRASHDUMP.Checked = !rcc_ignoreCRASHDUMP.Checked;
        }

        private void rcb_hidearchiveLogs_Click(object sender, EventArgs e)
        {
            rcb_hidearchiveLogs.Checked = !rcb_hidearchiveLogs.Checked;

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "HideArchiveLogs", Convert.ToString(rcb_hidearchiveLogs.Checked));

            if (rcb_hidearchiveLogs.Checked)
            {
                switches_hide_archiveLogs = true;

                dgv_Logs.Columns["dgv_c_Type"].Visible = false;

                renderLogs(true, "");
            }
            else
            {
                switches_hide_archiveLogs = false;

                dgv_Logs.Columns["dgv_c_Type"].Visible = true;

                renderLogs(true, "");
            }

            notificationMessage(this.tv_Logs.SelectedNode.Text + " contains " + dgv_Logs.Rows.Count.ToString() + " objects - " + getSaying(), this.BackColor);
        }

        private void rcc_sortbyModified_Click(object sender, EventArgs e)
        {
            rcc_sortbyModified.Checked = !rcc_sortbyModified.Checked;
        }

        private void dgv_Logs_Click(object sender, EventArgs e)
        {
            ribbon1.ActiveTab = rt_Home;
        }

        private void tv_Logs_Click(object sender, EventArgs e)
        {
            ribbon1.ActiveTab = rt_Home;
        }

        private void tv_Logs_MouseEnter(object sender, EventArgs e)
        {
            if (!switches_pin_Slider)
            {

                if (switches_Slider)
                {
                    switches_Slider = false;
                    Thread.Sleep(500);
                }

                splitContainer1.SplitterDistance = 200;

            }
        }

        private void tv_Logs_MouseLeave(object sender, EventArgs e)
        {
            // Check if we are hovering over the pb_pinSlider control, do not slide out if so

            Point p = Control.MousePosition;
            Point p1 = pb_pinSlider.PointToClient(p);
            Point p2 = splitContainer1.Panel1.PointToClient(p);

            if (pb_pinSlider.DisplayRectangle.Contains(p1) && splitContainer1.Panel1.DisplayRectangle.Contains(p2))
            {
                return;
            }

            if (!switches_pin_Slider)
            {
                if (visualEffects) // Not an RDP session so slide not snap
                {
                    // Set back to minimised

                    BackgroundWorker bw = new BackgroundWorker();
                    bw.WorkerSupportsCancellation = true;
                    bw.WorkerReportsProgress = true;
                    bw.DoWork +=
                        new DoWorkEventHandler(bw_slider_DoWork);
                    bw.ProgressChanged +=
                        new ProgressChangedEventHandler(bw_slider_ProgressChanged);
                    bw.RunWorkerCompleted +=
                        new RunWorkerCompletedEventHandler(bw_slider_RunWorkerCompleted);

                    tv_Logs.Visible = false;

                    pb_pinSlider.Visible = false;

                    bw.RunWorkerAsync(splitContainer1.SplitterDistance);
                }
                else // RDP session so snap not slide
                {
                    pb_snapOut.Visible = true;

                    pb_pinSlider.Visible = false;

                    tv_Logs.Visible = false;

                    splitContainer1.SplitterDistance = 0;
                }
            }
        }

        private void pb_snapOut_MouseEnter(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 200;

            pb_snapOut.Visible = false;

            tv_Logs.Visible = true;

            pb_pinSlider.Visible = true;
        }

        private void pb_pinSlider_Click(object sender, EventArgs e)
        {
            switches_pin_Slider = !switches_pin_Slider;
        }

        private void pb_Test_Click(object sender, EventArgs e)
        {
            switches_pin_Slider = !switches_pin_Slider;

            if (switches_pin_Slider)
            {
                Bitmap imagepinDown = new Bitmap(loadimagefromString(imagespinDown));

                pb_pinSlider.Image = imagepinDown;
            }
            else
            {
                Bitmap imagepinUp = new Bitmap(loadimagefromString(imagespinUp));

                pb_pinSlider.Image = imagepinUp;
            }


        }

        private void dgv_Logs_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tspb_Monitoring_Click(object sender, EventArgs e)
        {
            ribbon1.ActiveTab = rt_Home;
        }

        private void tspb_Monitoring_DoubleClick(object sender, EventArgs e)
        {
            ribbon1.ActiveTab = rt_Home;
        }

        private void zipLogs(logitemCollection alogitemCollection, string zipfileName)
        {
            try
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.WorkerReportsProgress = true;
                bw.DoWork +=
                    new DoWorkEventHandler(bw_zipLogs_DoWork);
                bw.ProgressChanged +=
                    new ProgressChangedEventHandler(bw_zipLogs_ProgressChanged);
                bw.RunWorkerCompleted +=
                    new RunWorkerCompletedEventHandler(bw_zipLogs_RunWorkerCompleted);

                filenamecollectioncombinedConfig afilenamecollectioncombinedConfig = new filenamecollectioncombinedConfig();

                afilenamecollectioncombinedConfig.fileName = zipfileName;

                afilenamecollectioncombinedConfig.alogitemCollection = alogitemCollection;

                tspb_zipfileCount.Visible = true;
                tspb_zipfileProgress.Visible = true;

                zipthreadRunning = true;

                bw.RunWorkerAsync(afilenamecollectioncombinedConfig);
            }
            catch (Exception ee)
            {

            }
        }

        private void tsmi_Ziplogs_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedTreeNode = tv_Logs.SelectedNode;

                string targetforComparison = selectedTreeNode.Text;

                string targetDevice = gettvselectednodedeviceName();

                if (selectedTreeNode != null) // Check if the treeview has a selected node, skip if it is and notify
                {
                    // Form up the list of logs from the global dataset that will be zipped up based on the treeviews currently selected node

                    logitemCollection tozipLogs = new logitemCollection();

                    foreach (logItem alogItem in globallogitemCollection)
                    {
                        if (targetDevice == alogItem.logDevice)
                        {
                            if (alogItem.logClass == selectedTreeNode.Text || alogItem.logProduct == selectedTreeNode.Text)
                            {
                                tozipLogs.Add(alogItem);
                            }
                            else if (targetforComparison == targetDevice)
                            {
                                tozipLogs.Add(alogItem);
                            }
                        }
                    }

                    notificationMessage("Zipping log files ...", this.BackColor);

                    string zipfileName = Path.Combine(rtb_zipoutputDirectory.TextBoxText, selectedTreeNode.FullPath.ToString().Replace(@"\", "-") + "-" + DateTime.Now.ToString("dd-MM-HH-mm") + ".zip");

                    diagnosticMessage("Zipping log files into " + zipfileName);

                    zipLogs(tozipLogs, zipfileName);
                }
                else
                {
                    notificationMessage("Zip aborted, nothing selected", this.BackColor);
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void rtb_zipoutputDirectory_TextBoxTextChanged(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "ZIPOutputFolder", rtb_zipoutputDirectory.TextBoxText);
        }

        private void rtb_zipoutputDirectory_TextBoxValidated(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "ZIPOutputFolder", rtb_zipoutputDirectory.TextBoxText);
        }

        private void rb_zipoutputdirectorySelect_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog aFolderBrowserDialog = new FolderBrowserDialog();

                DialogResult aDialogResult = aFolderBrowserDialog.ShowDialog();

                if (aDialogResult == DialogResult.OK) // Set for current session, and store in registry
                {
                    rtb_zipoutputDirectory.TextBoxText = aFolderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void tsmi_openzipFolder_Click(object sender, EventArgs e)
        {
            // Open log folder

            try
            {
                ProcessStartInfo newProcess = new ProcessStartInfo();

                newProcess.FileName = rtb_zipoutputDirectory.TextBoxText;

                newProcess.Arguments = "";

                newProcess.CreateNoWindow = false;

                newProcess.UseShellExecute = true;

                try
                {
                    Process.Start(newProcess);
                }
                catch (Exception ee)
                {
                    notificationMessage("Could not open ZIP folder " + ee.Message, this.BackColor);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion opening ZIP folder - " + ee.Message);
            }
        }

        private string gettvselectednodeCategory()
        {
            string returnValue = "";

            try
            {
                if (!tv_Logs.SelectedNode.FullPath.Contains(@"\"))
                {
                    returnValue = tv_Logs.SelectedNode.FullPath;
                }
                else
                {
                    returnValue = tv_Logs.SelectedNode.FullPath.Substring(0, tv_Logs.SelectedNode.FullPath.IndexOf(@"\"));
                }
            }
            catch (Exception ee)
            {

            }

            return returnValue;
        }

        private string gettvselectednodedeviceName()
        {
            string returnValue = "";

            try
            {
                if (!tv_Logs.SelectedNode.FullPath.Contains(@"\"))
                {
                    returnValue = tv_Logs.SelectedNode.FullPath;
                }
                else
                {
                    returnValue = tv_Logs.SelectedNode.FullPath.Substring(0, tv_Logs.SelectedNode.FullPath.IndexOf(@"\"));
                }
            }
            catch (Exception ee)
            {

            }

            return returnValue;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (switches_threadRunning) // Check if monitoring, change text accordingly
            {
                tsmi_monitorNode.Text = "Stop Monitoring";
            }
            else
            {
                tsmi_monitorNode.Text = "Monitor Node";
            }

            if (zipthreadRunning) // Check if zipping, change text accordingly
            {
                tsmi_Ziplogs.Enabled = false;
            }
            else
            {
                tsmi_Ziplogs.Enabled = true;
            }
        }

        private void tv_Logs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button ==  System.Windows.Forms.MouseButtons.Right)
            {
                e.Node.TreeView.SelectedNode = e.Node;
            }
        }

        private void rtb_configurezipFolder_Click(object sender, EventArgs e)
        {
            // Change the tab to show the Configuration tab where the ZIP folder is configured

            ribbon1.ActiveTab = rt_Trace;
        }

        private void tsmi_monitorNode_Click(object sender, EventArgs e)
        {
            beginMonitoring();
        }

        private void rcb_refreshnodesonClick_Click(object sender, EventArgs e)
        {
            rcb_refreshnodesonClick.Checked = !rcb_refreshnodesonClick.Checked;
        }

        private void tv_Logs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                refreshLogs();
            }
        }

        private void rcb_Fonts_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            rcb_Fonts.SelectedItem = e.Item;

            globalfontName = e.Item.Text;

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "Font", Convert.ToString(e.Item.Text));          
        }

        private void rup_fontSize_DownButtonClicked(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt16(rup_fontSize.Value) > 8 )
            {
                rup_fontSize.Value = (Convert.ToInt16(rup_fontSize.Value) - 1).ToString(); ;

                rup_fontSize.TextBoxText = rup_fontSize.Value;
            }

            globalfontSize = Convert.ToInt16(rup_fontSize.Value);

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "FontSize", Convert.ToString(globalfontSize));
        }

        private void rup_fontSize_UpButtonClicked(object sender, MouseEventArgs e)
        {
            if (Convert.ToInt16(rup_fontSize.Value) < 15)
            {
                rup_fontSize.Value = (Convert.ToInt16(rup_fontSize.Value) + 1).ToString(); ;

                rup_fontSize.TextBoxText = rup_fontSize.Value;
            }

            globalfontSize = Convert.ToInt16(rup_fontSize.Value);

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"), "FontSize", Convert.ToString(globalfontSize));
        }
    }
}
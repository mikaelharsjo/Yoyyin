param($installPath, $toolsPath, $package, $project)

if ($host.Version.Major -eq 1 -and $host.Version.Minor -lt 1) 
{ 
    throw "NOTICE: This package only works with NuGet 1.1 or above. Please update your NuGet install at http://nuget.codeplex.com. Sorry, but you're now in a weird state. Please 'uninstall-package AddMvc3ToWebForms' now."
}
else
{
    if($project.Type -eq 'C#') {
        $project.Object.References.Add("Microsoft.CSharp"); 
    }
    $project.Object.References.Add("System.Web.Mvc, Version=3.0.0.0"); 
    $project.Object.References.Add("System.Web.Routing, Version=4.0.0.0"); 
    $project.Object.References.Add("Microsoft.Web.Infrastructure, Version=1.0.0.0"); 
    $project.Object.References.Add("System.Web.WebPages, Version=1.0.0.0"); 
    $project.Object.References.Add("System.Web.Razor, Version=1.0.0.0"); 
    $project.Object.References.Add("System.ComponentModel.DataAnnotations, Version=4.0.0.0"); 
    
    #Here it is (HACK WARNING :)). 

    # The ASP.NET MVC 3 Guid
    $mvcGuid = "{E53F8FEA-EAE0-44A6-8774-FFD645390401}"
    
    $solutionExplorerGuid = "{3AE79031-E1BC-11D0-8F78-00A0C9110057}"

    # Get the IVSolution
    $vsSolution = Get-VSService ([Microsoft.VisualStudio.Shell.Interop.SVsSolution]) ([Microsoft.VisualStudio.Shell.Interop.IVsSolution])

    # Hierarchy
    #WRONG
    #$vsHierarchy = $vsSolution.GetProjectOfUniqueName($project.UniqueName)[1]
    $vsHierarchy = $null
    $vsSolution.GetProjectOfUniqueName($project.UniqueName, [ref] $vsHierarchy)
    Get-interface $vsHierarchy ([Microsoft.VisualStudio.Shell.Interop.IVsHierarchy])
     
    $aggregatableProject = Get-Interface $vsHierarchy ([Microsoft.VisualStudio.Shell.Interop.IVsAggregatableProject])
    
    # Get the current guids
    $projectGuids = $aggregatableProject.GetAggregateProjectTypeGuids()[1].ToUpperInvariant()

    # If it's not already there add it
    if(!$projectGuids.Contains($mvcGuid)) {
        # Add the mvc guid
        $projectGuids = "$mvcGuid;$projectGuids"
        $aggregatableProject.SetAggregateProjectTypeGuids($projectGuids)

        # Save and reload the project
        $project.Save()
        
        #That magic GUID is the "Solution Explorer" magic GUID
        $solutionName = $dte.Windows.Item($solutionExplorerGuid).Object.UiHierarchyItems | select -expand Name
        $dte.Windows.Item($solutionExplorerGuid).Object.GetItem("$solutionName\$($project.Name)").Select(1)
        
        # Unload the project
        $dte.ExecuteCommand("Project.UnloadProject");
        
        # Reload it so that the tooling shows up
        $dte.ExecuteCommand("Project.ReloadProject");
    }
}
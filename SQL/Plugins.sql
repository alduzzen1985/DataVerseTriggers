SELECT primaryobjecttypecode,
sdkmessageprocessingstepid, 
SPM.name,
SPM.sdkmessageidname,
SPM.componentstate, 
SPM.componentstatename,
filteringattributes,
mode, modename,
SPM.sdkmessageid, sdkmessagefilteridname,
stage, stagename
FROM sdkmessageprocessingstep SPM 
JOIN sdkmessagefilter SMF ON SPM.sdkmessagefilterid = SMF.sdkmessagefilterid 
JOIN solutioncomponent SC ON SC.componenttype = 92 AND SPM.sdkmessageprocessingstepid = SC.objectid
WHERE SC.solutionid = 'fd140aaf-4df4-11dd-bd17-0019b9312238' AND stage IN (10,20,40) AND
(
filteringattributes LIKE '%address1_line1%' OR
filteringattributes LIKE '%address1_line2%' 
)



SELECT friendlyname,solutionid
FROM solution
WHERE friendlyname like '%Default%'


SELECT *
FROM sdkmessage 
WHERE sdkmessageid IN (
'eb9990f6-feff-497f-974c-eb457ee0d072',
'e2ac2e19-aea0-47a3-b024-f7a7015b4d60'
)
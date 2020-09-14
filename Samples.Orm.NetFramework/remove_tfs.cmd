attrib *.vssscc /s -r -h 
del *.vssscc /s 
attrib *.vspsscc /s -r -h 
del *.vspscc /s 
attrib obj /d /s -r -h 
attrib bin /d /s -r -h 
FOR /F %I IN ('dir obj /s /b') DO RMDIR %I /s /q

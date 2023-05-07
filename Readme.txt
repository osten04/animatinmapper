Programet är inspirerat av en devlog på astortion
https://www.youtube.com/watch?v=HsOKwUwL1bE
Målet av programet är att separera animation och textur 
så att man slipper göra varje animation med varje textur var för sig

Det fungerar på så sätt att den tar varje pixel i an så kallad map
och mappar den till en pixel på samma position i en textur.

Sen tar man varje frame i animatinen och byter varje 
färjlagd pixel till den färgen den är mapad till.
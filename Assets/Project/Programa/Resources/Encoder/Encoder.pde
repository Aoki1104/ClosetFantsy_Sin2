import processing.serial.*;
Serial port;
String filename;
PrintWriter file;
int in_data = 0;

void setup() {
  size(300, 300);
  port = new Serial(this, "COM2", 9600);
  background(0, 0, 0);
  filename = "WorldNumber.txt";
  
}

void draw() {

  if (port.available() > 0 ) {
    file = createWriter(filename);
    in_data = port.read();
    file.print(in_data);
    file.close();
   println(in_data);
  }

}

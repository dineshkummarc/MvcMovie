

d = "sdfaadsf"
 
testDir = "TestResults/aaaaaa"  # DateTime.now.strftime("%Y-%m-%d_%H-%M") 
#Dir.chdir("..")
if !File::directory?(testDir)
	puts "NOOOOOOOOOO"
	 #FileUtils.mkdir_p(testDir)
	d = Dir.mkdir(testDir)   
end
=begin

myfile = File.new(testDir+"/write.txt", "w+")    # open file for read and write  
myfile.puts("This test line 1")         # write a line 
myfile.puts("This test line 2")         # write a second line 
myfile.rewind                           # move pointer back to start of file 
puts myfile.readline 
puts myfile.readline 


=end

=begin
# this is working with saving screenshots
require 'watir-webdriver' 
require 'test/unit'


b = Watir::Browser.new
b.goto 'bit.ly/watir-webdriver-demo'
b.text_field(:id => 'entry_0').set 'some long name'
b.driver.save_screenshot 'screenshot.png' 
b.close


=end



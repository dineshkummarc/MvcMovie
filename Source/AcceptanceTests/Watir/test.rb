

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




=begin

require 'watir-webdriver'
require 'test/unit' 

class Payment 
  attr_accessor :cardType, :cardNumber , :expiration, :nameOnCard, :securityNumber, :city,  :state,  :zipCode 
  
  def initialize(h)
    h.each {|k,v| send("#{k}=",v)}
  end
   
end



class TC_article_example < Test::Unit::TestCase
  
  @@testDir = '/TestResults/' +DateTime.now.strftime("%Y-%m-%d_%H-%M")

  def test_payment_form  
	puts 'results in  ' + @@testDir
	if(File.directory?(@@testDir))
		puts 'YESSSS'
	else
		File.new(@@testDir+ "/results.txt", "w").path 
		puts 'created'
	end
	
	p = fill_out_payment_form() 
	check_payment_table (p)
	
  end
  
   
  def check_payment_table p  
    b = Watir::Browser.new
    b.goto("http://localhost:38519/Account/LogOn") 
    b.text_field(:name, "UserName").set("a") 
    b.text_field(:name, "Password").set("XXXXXXXXXX") 
    b.button(:type, "submit").click 
    b.goto("http://localhost:38519/Admin/Payments")  
	b.driver.save_screenshot @@testDir + '/check_payment_table.png'
	puts p.cardType
	assert(b.text.include?( p.cardType) )  
  end 

  def fill_out_payment_form()
    b = Watir::Browser.new 
    b.goto("http://localhost:38519/payment") 
	p = Payment.new(:cardType => "Discover", :cardNumber => "234234234234", :expiration => "2/2021", 
					:nameOnCard => "Test Tester",:securityNumber => "2121", :city => "city", 
					:state => "il", :zipCode => "21321" ) 
	p.cardType = p.cardType + Random.rand(0 - 100_000).to_s
    b.text_field(:name, "CardType").set(p.cardType) 
    b.text_field(:name, "CardNumber").set(p.cardNumber) 
    b.text_field(:name, "Expiration").set(p.expiration) 
    b.text_field(:name, "NameOnCard").set(p.nameOnCard) 
    b.text_field(:name, "SecurityNumber").set(p.securityNumber) 
    b.text_field(:name, "City").set(p.city)  
    b.text_field(:name, "State").set(p.state)  
    b.text_field(:name, "ZipCode").set(p.zipCode) 
	#b.driver.save_screenshot 'screenshot.png'

	b.driver.save_screenshot @@testDir + '/fill_out_payment_form.png' 
    b.button(:type, "submit").click 
    assert(b.text.include?("ThankYou"))    
	return p
  end
  
   
  
end

=end








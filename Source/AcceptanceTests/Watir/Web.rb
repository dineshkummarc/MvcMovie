require 'watir'
require 'test/unit'

class TC_article_example < Test::Unit::TestCase
 
 
  
  def test_discover_merchant_rebate
    b = Watir::Browser.new
    b.goto("http://www.yahoo.com") 
    b.text_field(:name, "p").set("watir") 
    b.button(:id, "search-submit").click 
    assert(b.text.include?("Watir.com | Web Application Testing in Ruby"))   
  end

  
  
  def NotAtest_discover_merchant_rebate
    b = Watir::Browser.new
    b.goto("http://www.yahoo.com")
    b.link(:id, "continue").click 
    assert(b.text.include?("Please complete the enrollment form below and submit on or before"))

	assert(b.text_field(:name, "CorpName").exists?) 
    b.text_field(:name, "FirstName").set("qatestFirstName") 
    b.image(:class, "submit btnRegContinue").click 
    assert(b.text.include?("Required information to complete your enrollment. Please fill in")) 
    b.text_field(:name, "CorpName").set("qatestCorp")
    b.text_field(:name, "DBAName").set("qatestDBAName")
    b.text_field(:name, "FirstName").set("qatestFirstName") 
    b.text_field(:name, "LastName").set("qatestLastName")
    b.text_field(:name, "Title").set("qatestTitle")
    b.text_field(:name, "Phone").set("555-555-5555")
    b.text_field(:name, "Address1").set("qatestAddress1") 
	b.text_field(:name, "City").set("qatestCity") 
    b.select_list(:name, "State").set("AL") 
	b.text_field(:name, "Email").set("qatest@test.com") 
    b.text_field(:name, "Email2").set("qatest@test.com") 
    b.text_field(:name, "Zip").set("11111") 
	
	b.image(:class, "submit btnRegContinue").click   
	b.wait_until{b.image(:id => "btnConfirm").present?}
	b.image(:id, "btnConfirm").click  
	assert(b.text.include?("You must check the confirmation box to continue") ) 
	
	b.checkboxes(:class => 'clickHere left').each {|checkbox| checkbox.set if checkbox.visible?}
 
	b.image(:id, "btnConfirm").click  
	
	b.wait_until{b.text.include?("You will receive an e-mail within 7-10 business days confirming your enrollment")}
	assert(b.text.include?("You will receive an e-mail within 7-10 business days confirming your enrollment") )  
  end
  
  
end







require 'watir'
require 'test/unit'

class TC_article_example < Test::Unit::TestCase
 
 
  
  def test_discover_merchant_rebate
    browser = Watir::Browser.new
    browser.goto("http://www.yahoo.com") 
    browser.text_field(:name, "p").set("watir") 
    browser.button(:id, "search-submit").click 
    assert(browser.text.include?("Watir.com | Web Application Testing in Ruby"))   
  end

  
  
  def NotAtest_discover_merchant_rebate
    browser = Watir::Browser.new
    browser.goto("http://www.yahoo.com")
    browser.link(:id, "continue").click 
    assert(browser.text.include?("Please complete the enrollment form below and submit on or before"))

	assert(browser.text_field(:name, "CorpName").exists?) 
    browser.text_field(:name, "FirstName").set("qatestFirstName") 
    browser.image(:class, "submit btnRegContinue").click 
    assert(browser.text.include?("Required information to complete your enrollment. Please fill in")) 
    browser.text_field(:name, "CorpName").set("qatestCorp")
    browser.text_field(:name, "DBAName").set("qatestDBAName")
    browser.text_field(:name, "FirstName").set("qatestFirstName") 
    browser.text_field(:name, "LastName").set("qatestLastName")
    browser.text_field(:name, "Title").set("qatestTitle")
    browser.text_field(:name, "Phone").set("555-555-5555")
    browser.text_field(:name, "Address1").set("qatestAddress1") 
	browser.text_field(:name, "City").set("qatestCity") 
    browser.select_list(:name, "State").set("AL") 
	browser.text_field(:name, "Email").set("qatest@test.com") 
    browser.text_field(:name, "Email2").set("qatest@test.com") 
    browser.text_field(:name, "Zip").set("11111") 
	
	browser.image(:class, "submit btnRegContinue").click   
	browser.wait_until{browser.image(:id => "btnConfirm").present?}
	browser.image(:id, "btnConfirm").click  
	assert(browser.text.include?("You must check the confirmation box to continue") ) 
	
	browser.checkboxes(:class => 'clickHere left').each {|checkbox| checkbox.set if checkbox.visible?}
 
	browser.image(:id, "btnConfirm").click  
	
	browser.wait_until{browser.text.include?("You will receive an e-mail within 7-10 business days confirming your enrollment")}
	assert(browser.text.include?("You will receive an e-mail within 7-10 business days confirming your enrollment") )  
  end
  
  
end







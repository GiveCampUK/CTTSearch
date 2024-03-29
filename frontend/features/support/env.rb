$:.push File.realpath(File.join(File.dirname(__FILE__), *%w[.. ..]))
app_file = File.join(File.dirname(__FILE__), *%w[.. .. frontend.rb])
require app_file
# Force the application name because polyglot breaks the auto-detection logic.
Sinatra::Application.app_file = app_file

require 'rspec/expectations'
require 'cucumber/rspec/doubles'
require 'rack/test'
require 'webrat'
require 'frontend'

Webrat.configure do |config|
  config.mode = :rack
end

class MyWorld
  include Rack::Test::Methods
  include Webrat::Methods
  include Webrat::Matchers

  Webrat::Methods.delegate_to_session :response_code, :response_body

  def app
    Sinatra::Application
  end
end

World{MyWorld.new}
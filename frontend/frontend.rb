$:. << './lib'

require 'sinatra'
require 'sinatra/base'
require 'sinatra/content_for'

class Frontend < Sinatra::Base
  helpers Sinatra::ContentFor
  set :root, File.dirname(__FILE__)
  
  get '/' do
    erb :index
  end
end
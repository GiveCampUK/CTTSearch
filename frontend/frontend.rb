$:. << './lib'

require 'sinatra'
require 'sinatra/base'
require 'sinatra/content_for'
require 'frontend'

class Frontend < Sinatra::Base
  helpers Sinatra::ContentFor
  set :root, File.dirname(__FILE__)
  
  get '/' do
    @categories = Categories.top
    erb :index
  end

  get '/result' do
  	erb :result
  end

  get '/results' do
  	erb :results
  end
end
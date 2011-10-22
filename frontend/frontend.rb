$:. << './lib'

require 'sinatra'
require 'sinatra/base'
require 'sinatra/content_for'
require 'frontend'

class Frontend < Sinatra::Base
  helpers Sinatra::ContentFor
  set :root, File.dirname(__FILE__)
  
  get '/' do
    @categories = Categories.all
    erb :index
  end

  get '/search' do
  	erb :result
  end
  
  get '/process' do
    builder = SearchUriBuilder.new(params[:query],[ params[:org_size], params[:user_prof]])
    redirect builder.uri
  end
end
$:. << './lib'

require 'sinatra'
require 'sinatra/base'
require 'sinatra/content_for'

class Frontend < Sinatra::Base
  helpers Sinatra::ContentFor
  
  get '/' do
    erb :index
  end
end
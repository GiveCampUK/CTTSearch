$:. << './lib'

require 'sinatra'
require 'sinatra/base'
require 'sinatra/content_for'

class Frontend < Sinatra::Base
  get '/' do
    "CTT Search Ahoy!"
  end
end
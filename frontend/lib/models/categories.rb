require 'uri'

module Categories
  # TODO: Re-Implement with Actual Calls Once API Becomes Available
  
  def self.all
    [
      { :title => "Email", :blurb => "How to set up and configure email", :tags => [:email] },
      { :title => "Getting on the Web", :blurb => "What's a host? How to get your charity online.", :tags => [:web, :hosting] },
      { :title => "Donations", :blurb => "How to process payments. PCI compliance", :tags => [:payments, :dontations]}
    ]
  end
  
  def self.top
    categories = all
    categories.map do |cat|
      {
        :title => cat[:title],
        :blurb => cat[:blurb],
        :top_search => search_uri("", cat[:tags])
      }
    end
  end
  
  private
  
  def self.base_uri
    "http://searchparty-1.apphb.com"
  end
  
  def self.escaped(val)
    URI.escape(val, Regexp.new("[^#{URI::PATTERN::UNRESERVED}]"))
  end
  
  def self.search_terms(q = "", tags = [ ])
    result = [ ]
    result << q unless q.strip
    result | tags
  end
  
  def self.search_uri(q = "", *tags)
    formatted_tags = tags.flatten.map{ |t| "^#{t}"  }
    params = "?q=#{escaped search_terms(q, formatted_tags).join(" ")}"
    "#{base_uri}/search/#{params}"
  end
end
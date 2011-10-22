class SearchUriBuilder
  
  def initialize(query, *tags)
    @query = query
    @tags = tags.flatten
  end
  
  def uri
    "/search#{query_string}"
  end
  
  def query_string
    SearchUriBuilder.query_string @query, @tags
  end
  
  def self.query_string(q = "", *tags)
    formatted_tags = tags.flatten.map{ |t| "^#{t}"  }
    "?q=#{escaped search_terms(q, formatted_tags).join(" ")}"
  end
  
  private
  
  def self.escaped(val)
    URI.escape(val, Regexp.new("[^#{URI::PATTERN::UNRESERVED}]"))
  end
  
  def self.search_terms(q = "", tags = [ ])
    tags << (q unless q.strip)
  end
end
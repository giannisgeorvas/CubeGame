#
# Copyright (c) 2001 by Sun Microsystems, Inc.
# All rights reserved.
#
# ident	"@(#)local.profile	1.10	01/06/23 SMI"
PATH=/usr/local/bin:/usr/bin:/bin
export PATH
export LEDAROOT=/usr/local/leda
export LD_LIBRARY_PATH=${LEDAROOT}:$LD_LIBRARY_PATH
#export MANPATH=/usr/man:/usr/dt/man:/usr/openwin/man:/usr/local/man:/usr/sfw/man:/opt/sfw/man
ulimit -u 500
umask 077
